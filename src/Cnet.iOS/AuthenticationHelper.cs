using System;
using MonoTouch.Foundation;
using MonoTouch.Security;
using MonoTouch.UIKit;
using Cnt.API;

namespace Cnet.iOS
{
	public static class AuthenticationHelper
	{
		public static Client GetClient()
		{
			string username = NSUserDefaults.StandardUserDefaults.StringForKey ("username");
			string password = KeychainHelpers.GetPasswordForUsername (username ?? String.Empty, Constants.NTMOBILE_APPLICATION_ID, true);
			if (String.IsNullOrWhiteSpace (username) || String.IsNullOrWhiteSpace (password))
				return null;
			return new Client (username, password);
		}

		public static void Authenticate(string username, string password)
		{
			string deviceId = UIDevice.CurrentDevice.IdentifierForVendor.AsString ();
			Client client = new Client (username, password);
			client.AuthenticateService.Authenticate (deviceId, "ios");

			NSUserDefaults.StandardUserDefaults.SetString (username, "username");
			KeychainHelpers.SetPasswordForUsername (username, password, Constants.NTMOBILE_APPLICATION_ID, SecAccessible.Always, true);
		}

		public static void LogOut()
		{
			string username = NSUserDefaults.StandardUserDefaults.StringForKey ("username");
			if (!String.IsNullOrEmpty (username)) {
				KeychainHelpers.DeletePasswordForUsername (username, Constants.NTMOBILE_APPLICATION_ID, true);
				NSUserDefaults.StandardUserDefaults.RemoveObject ("username");
			}
		}
	}
}

