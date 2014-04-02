using Cnt.API.Exceptions;
using Cnt.Web.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Cnt.API
{
	public sealed class CntRestHelper
	{
		public enum RequestMethod
		{
			GET, POST, PUT, DELETE
		}

		#region Dictionary Converter
		private class NestedDictionaryConverter : CustomCreationConverter<IDictionary<string, object>>
		{
			public override IDictionary<string, object> Create(Type objectType)
			{
				return new Dictionary<string, object>();
			}

			public override bool CanConvert(Type objectType)
			{
				// in addition to handling IDictionary<string, object>
				// we want to handle the deserialization of dict value
				// which is of type object
				return objectType == typeof(object) || base.CanConvert(objectType);
			}

			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				if (reader.TokenType == JsonToken.StartObject
					|| reader.TokenType == JsonToken.Null)
					return base.ReadJson(reader, objectType, existingValue, serializer);

				// if the next token is not an object
				// then fall back on standard deserializer (strings, numbers etc.)
				return serializer.Deserialize(reader);
			}
		}
		#endregion

		public class CntResponse<T>
		{
			private CntResponse _Response;

			public CntResponse(CntResponse response)
			{
				_Response = response;
			}

			public CntResponse Response { get { return _Response; } }

			public T Data { get { return CntRestHelper.Deserialize<T>(_Response.Data); } }
		}

		public class CntResponse
		{
			public CntResponse(HttpWebRequest request)
			{
				try
				{
					using (var response = request.GetResponse())
					{
						ContentType = response.ContentType;
						HttpStatusCode = ((HttpWebResponse)response).StatusCode;

						using (StreamReader sr = new StreamReader(response.GetResponseStream()))
						{
							Data = sr.ReadToEnd();
						}
					}
				}
				catch (WebException e) // We get a WebException on everything but 200.
				{
					using (WebResponse response = e.Response)
					{
						ContentType = response.ContentType;
						HttpStatusCode = ((HttpWebResponse)response).StatusCode;
						using (StreamReader sr = new StreamReader(response.GetResponseStream()))
						{
							Data = sr.ReadToEnd();
						}
						ApiErrors = CntRestHelper.Deserialize<IEnumerable<ApiError>>(Data);
						string message;
						if (ApiErrors != null)
						{
							if (ApiErrors.Count() > 1)
								message = "Multiple errors occurred, see ApiErrors for details.";
							else
								message = ApiErrors.FirstOrDefault().Message;
						}
						else
							message = String.Format("The web request returned {0} {1}.", (int)HttpStatusCode, HttpStatusCode.ToString());
						throw new CntResponseException(message, ApiErrors);
					}
				}
			}

			public IEnumerable<ApiError> ApiErrors { get; set; }
			public string ContentType { get; set; }
			public string Data { get; set; }
			public HttpStatusCode HttpStatusCode { get; set; }
			public Dictionary<string, string> RequestData { get; set; }
			public string RequestUri { get; set; }
		}

		public static CntResponse Request(string requestUri, string userName, string password, Dictionary<string, string> requestData = null, RequestMethod requestMethod = RequestMethod.GET)
		{
			if (String.IsNullOrEmpty(userName))
				throw new ArgumentNullException("userName");
			if (String.IsNullOrEmpty(password))
				throw new ArgumentNullException("password");

			requestData = requestData ?? new Dictionary<string, string>();

			HttpWebRequest request;

			if (requestMethod == RequestMethod.GET)
			{
				// Lets add the different arguments if they are present.
				if (requestData.Count > 0)
				{
					requestUri = requestUri + "?" + string.Join("&", requestData.Select(x => x.Key + "=" + Uri.EscapeDataString(x.Value)).ToArray());
				}
				request = (HttpWebRequest)WebRequest.Create(requestUri);

				SetBasicAuthHeader(request, userName, password);

				request.ContentType = "application/x-www-form-urlencoded";
				request.Accept = "application/json";
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(requestUri);

				SetBasicAuthHeader(request, userName, password);

				request.Method = "POST";

				if (requestMethod == RequestMethod.PUT)
					request.Method = "PUT";

				string postData = string.Join("&", requestData.Select(x => x.Key != "" ? x.Key + "=" + x.Value : x.Value).ToArray());

				byte[] data = Encoding.UTF8.GetBytes(postData);

				request.ContentType = "application/x-www-form-urlencoded";
				request.Accept = "application/json";
				request.ContentLength = data.Length;

				using (Stream requestStream = request.GetRequestStream())
				{
					requestStream.Write(data, 0, data.Length);
				}
			}

			CntResponse retval = new CntResponse(request);

			retval.RequestData = requestData;
			retval.RequestUri = requestUri;

			return retval;
		}

		public static CntResponse<T> Request<T>(string requestUri, string userName, string password, Dictionary<string, string> requestData = null, RequestMethod requestMethod = RequestMethod.GET)
		{
			return new CntResponse<T>(Request(requestUri, userName, password, requestData, requestMethod));
		}

		public static CntResponse JSONRequest(string requestUri, string userName, string password, object requestData, RequestMethod requestMethod)
		{
			if (String.IsNullOrEmpty(userName))
				throw new ArgumentNullException("userName");
			if (String.IsNullOrEmpty(password))
				throw new ArgumentNullException("password");
			if (requestMethod == RequestMethod.GET)
				throw new ArgumentException("Only works with PUT/POST/DELETE");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

			SetBasicAuthHeader(request, userName, password);

			request.Method = "POST";

			if (requestMethod == RequestMethod.PUT) request.Method = "PUT";
			if (requestMethod == RequestMethod.DELETE) request.Method = "DELETE";

			string postData = Serialize(requestData);

			byte[] data = Encoding.UTF8.GetBytes(postData);

			request.ContentType = "application/json";
			request.Accept = "application/json";
			request.ContentLength = data.Length;

			using (Stream requestStream = request.GetRequestStream())
			{
				requestStream.Write(data, 0, data.Length);
			}

			CntResponse retval = new CntResponse(request);

			retval.RequestData = new Dictionary<string, string>() { { "json", postData } };
			retval.RequestUri = requestUri;

			return retval;
		}

		public static CntResponse<T> JSONRequest<T>(string requestUri, string userName, string password, object requestData, RequestMethod requestMethod)
		{
			CntResponse<T> retval = new CntResponse<T>(JSONRequest(requestUri, userName, password, requestData, requestMethod));
			return retval;
		}

		#region Private Methods
		private static void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
		{
			string authInfo = userName + ":" + userPassword;
			authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
			request.Headers["Authorization"] = "Basic " + authInfo;
		}

		public static T Deserialize<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json, new JsonConverter[] { new NestedDictionaryConverter() });
		}

		public static string Serialize(object t)
		{
			return JsonConvert.SerializeObject(t);
		}
		#endregion
	}
}
