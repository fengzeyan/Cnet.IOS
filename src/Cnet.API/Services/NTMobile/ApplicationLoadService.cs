using Cnt.Web.API.Models;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing the application load for the current user.
	/// </summary>
	public class ApplicationLoadService
	{
		Client _Client;
		internal ApplicationLoadService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets the application load data.
		/// </summary>
		/// <returns>The application load data.</returns>
		public NTMobileAppLoadData GetAppLoadData()
		{
			return CntRestHelper.Request<NTMobileAppLoadData>(Constants.NTMOBILE_BASEURL + "/application-load", _Client.UserName, _Client.Password).Data;
		}
	}
}
