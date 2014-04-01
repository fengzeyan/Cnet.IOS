using Cnt.Web.API.Models;
using System.Collections.Generic;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing notifications for the current user.
	/// </summary>
	public class NotificationService
	{
		Client _Client;
		internal NotificationService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets all notifications for the current user.
		/// </summary>
		/// <returns>All notifications for the current user.</returns>
		public IEnumerable<Notification> GetNotifications()
		{
			return CntRestHelper.Request<IEnumerable<Notification>>(Constants.NTMOBILE_BASEURL + "/notifications", _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Gets a notification.
		/// </summary>
		/// <param name="notificationId">The notification identifier.</param>
		/// <returns>The notification.</returns>
		public Notification GetNotification(int notificationId)
		{
			return CntRestHelper.Request<Notification>(Constants.NTMOBILE_BASEURL + "/notification/" + notificationId, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Acknowledges a notification.
		/// </summary>
		/// <param name="notificationId">The notification identifier.</param>
		/// <returns><c>true</c> if the notification was acknowledged, <c>false</c> otherwise.</returns>
		public void AcknowledgeNotification(int notificationId)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/notification/" + notificationId + "/acknowledge", _Client.UserName, _Client.Password, null, CntRestHelper.RequestMethod.PUT);
		}
	}
}
