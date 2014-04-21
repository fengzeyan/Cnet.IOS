using Cnt.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Cnt.API.Exceptions
{
	public class CntResponseException : Exception
	{
		public HttpStatusCode HttpStatusCode { get; private set; }
		public IEnumerable<ApiError> Errors { get; private set; }

		public CntResponseException(string message, IEnumerable<ApiError> errors)
			: base(message)
		{
			Errors = errors;
		}

		public CntResponseException(string message, HttpStatusCode httpStatusCode)
			: base (message)
		{
			HttpStatusCode = httpStatusCode;
		}
	}
}