using Cnt.Web.API.Models;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing authentication with the CNet API.
	/// </summary>
	public class AuthenticateService
	{
        Client _Client;
		internal AuthenticateService(Client client)
        {
            _Client = client;
        }

		/// <summary>
		/// Authenticates the user with the API and registers the specified device identifier (if it is not already registered) to receive push notifications from CNT
		/// </summary>
		/// <param name="deviceId">The device identifier.</param>
		/// <returns>The user's application load data.</returns>
		public NTMobileAppLoadData Authenticate(string deviceId, string deviceType)
		{
			return CntRestHelper.Request<NTMobileAppLoadData>(Constants.NTMOBILE_BASEURL + "/authenticate?d=" + deviceId + "&t=" + deviceType, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Sends a password reminder email to the specified email address.
		/// </summary>
		/// <param name="email">The email address.</param>
		/// <returns><c>true</c> if a password reminder was sent to the specified email address, <c>false</c> otherwise.</returns>
		public void SendPasswordReminder(string email)
		{
			CntRestHelper.Request(Constants.NTMOBILE_BASEURL + "/password-lookup?e=" + email, Constants.NTMOBILE_APPLICATION_ID, Constants.NTMOBILE_APPLICATION_KEY);
		}
	}
}
