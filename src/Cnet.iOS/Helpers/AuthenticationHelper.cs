using System;
using MonoTouch.Foundation;
using MonoTouch.Security;
using MonoTouch.UIKit;
using Cnt.API;
using Cnt.Web.API.Models;
using System.Collections.Generic;
using Cnt.API.Exceptions;

namespace Cnet.iOS
{
	public static class AuthenticationHelper
	{
		private const string UserNameKey = "username";

		public static NTMobileAppLoadData UserData { get; set; }

		#region Public Methods
		public static Client GetClient()
		{
			string username = NSUserDefaults.StandardUserDefaults.StringForKey (UserNameKey);
			string password = KeychainHelpers.GetPasswordForUsername (username ?? String.Empty, Constants.NTMOBILE_APPLICATION_ID, true);
			if (String.IsNullOrWhiteSpace (username) || String.IsNullOrWhiteSpace (password))
				return null;
			return new Client (username, password);
		}

		public static bool Authenticate(string username, string password)
		{
			try {
				Client client = new Client (username, password);
				if(client == null)
					return false;
				string deviceId = UIDevice.CurrentDevice.IdentifierForVendor.AsString ();
				var data = client.AuthenticateService.Authenticate (deviceId, "ios");
				SaveAppLoadData (data);

				NSUserDefaults.StandardUserDefaults.SetString (username, UserNameKey);
				KeychainHelpers.SetPasswordForUsername (username, password, Constants.NTMOBILE_APPLICATION_ID, SecAccessible.Always, true);
			}
			catch (CntResponseException ex) {
				Utility.ShowError (ex);
				return false;
			}
			return true;
		}

		public static void LogOut()
		{
			// TODO: Deauthenticate.
			string username = NSUserDefaults.StandardUserDefaults.StringForKey (UserNameKey);
			if (!String.IsNullOrEmpty (username)) {
				KeychainHelpers.DeletePasswordForUsername (username, Constants.NTMOBILE_APPLICATION_ID, true);
				NSUserDefaults.StandardUserDefaults.RemoveObject (UserNameKey);
			}
		}

		public static bool UpdateAppLoadData ()
		{
			try {
				Client client = GetClient ();
				if (client == null) 
					return false;
				var data = client.ApplicationLoadService.GetAppLoadData ();
				SaveAppLoadData (data);
			} catch (CntResponseException ex) {
				Utility.ShowError (ex);
				return false;
			}
			return true;
		}
		#endregion

		private static void SaveAppLoadData(NTMobileAppLoadData loadData)
		{
			UserData = loadData;
		}
	}
}

