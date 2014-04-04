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
			string username = NSUserDefaults.StandardUserDefaults.StringForKey("username");
			string password = KeychainHelpers.GetPasswordForUsername (username, Constants.NTMOBILE_APPLICATION_ID, true);
			return new Client (username, password);
		}

		public static void Authenticate(string username, string password)
		{
			NSUserDefaults.StandardUserDefaults.SetString(username, "username");
			KeychainHelpers.SetPasswordForUsername(username, password, Constants.NTMOBILE_APPLICATION_ID, SecAccessible.Always, true);

			string deviceId = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			Client client = new Client(username, password);
			client.AuthenticateService.Authenticate(deviceId);
		}
	}
}

