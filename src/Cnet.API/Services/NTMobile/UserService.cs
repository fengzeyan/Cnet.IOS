using Cnt.Web.API.Models;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing users.
	/// </summary>
	public class UserService
	{
		Client _Client;
		internal UserService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets a user.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns>The user.</returns>
		public User GetUser(int userId)
		{
			return CntRestHelper.Request<User>(Constants.NTMOBILE_BASEURL + "/user/" + userId, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Gets profile status of the current user.
		/// </summary>
		/// <returns>The profile status of the current user.</returns>
		public NTMobileAppProfileStatus GetUserProfileStatus()
		{
			return CntRestHelper.Request<NTMobileAppProfileStatus>(Constants.NTMOBILE_BASEURL + "/user-profile-status", _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Updates a user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns><c>true</c> if the user was updated, <c>false</c> otherwise.</returns>
		public void UpdateUser(User user)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/user/" + user.Id, _Client.UserName, _Client.Password, user, CntRestHelper.RequestMethod.PUT);
		}
	}
}
