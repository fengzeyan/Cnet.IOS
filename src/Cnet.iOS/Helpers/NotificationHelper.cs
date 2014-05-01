using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using Cnt.Web.API.Models;
using Cnt.API.Exceptions;
using Cnt.API;

namespace Cnet.iOS
{
	public static class NotificationHelper
	{
		private static List<Notification> notifications;
		private static OSNotificationsViewController notificationsController;

		public static List<Notification> Notifications
		{
			get {
				if (notifications == null)
					LoadNotifications ();
				return notifications;
			}
		}

		public static void ShowNotificationView(UIViewController parent)
		{
			if (notificationsController == null) {
				notificationsController = parent.Storyboard.InstantiateViewController ("OSNotificationsViewController") as OSNotificationsViewController;
				notificationsController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
				notificationsController.ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve;
			}

			parent.PresentViewController(notificationsController, true, null);
		}

		private static void LoadNotifications ()
		{
			try {
				Client client = AuthenticationHelper.GetClient ();
				notifications = new List<Notification> (client.NotificationService.GetNotifications ());
			} catch (CntResponseException ex) {
				Utility.ShowError (ex);
			}
		}
	}
}

