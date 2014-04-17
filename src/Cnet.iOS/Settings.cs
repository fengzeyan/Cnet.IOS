using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using Cnt.Web.API.Models;

namespace Cnet.iOS
{
	public class Settings
	{
		private enum SettingsNames
		{
			HaveSettingsBeenLoadedBefore,
			ConfirmAssignment,
			SubmitTimesheet,
			AvailabilityRequired,
			AssignmentUpdated,
			AssignmentCanceled,
			AssignmentReminders,
			AssignmentConfirmationRequired
		}

		public bool ConfirmAssignment { get; set; }
		public bool SubmitTimesheet { get; set; }
		public bool AvailabilityRequired { get; set; }
		public bool AssignmentUpdated { get; set; }
		public bool AssignmentCanceled { get; set; }
		public bool AssignmentReminders { get; set; }
		public bool AssignmentConfirmationRequired { get; set; }

		public void Load()
		{
			bool isFirstSettingsLoad = (NSUserDefaults.StandardUserDefaults.BoolForKey(SettingsNames.HaveSettingsBeenLoadedBefore.ToString()) == false);
			if (isFirstSettingsLoad) {
				NSUserDefaults.StandardUserDefaults.SetBool (true, SettingsNames.HaveSettingsBeenLoadedBefore.ToString ());
				SetDefaults ();
			}

			ConfirmAssignment = NSUserDefaults.StandardUserDefaults.BoolForKey (SettingsNames.ConfirmAssignment.ToString ());
			SubmitTimesheet = NSUserDefaults.StandardUserDefaults.BoolForKey (SettingsNames.SubmitTimesheet.ToString ());
			AvailabilityRequired = NSUserDefaults.StandardUserDefaults.BoolForKey (SettingsNames.AvailabilityRequired.ToString ());
			AssignmentUpdated = NSUserDefaults.StandardUserDefaults.BoolForKey (SettingsNames.AssignmentUpdated.ToString ());
			AssignmentCanceled = NSUserDefaults.StandardUserDefaults.BoolForKey (SettingsNames.AssignmentCanceled.ToString ());
			AssignmentReminders = NSUserDefaults.StandardUserDefaults.BoolForKey (SettingsNames.AssignmentReminders.ToString ());
			AssignmentConfirmationRequired = NSUserDefaults.StandardUserDefaults.BoolForKey (SettingsNames.AssignmentConfirmationRequired.ToString ());
		}

		public void Save()
		{
			NSUserDefaults.StandardUserDefaults.SetBool (ConfirmAssignment, SettingsNames.ConfirmAssignment.ToString ());
			NSUserDefaults.StandardUserDefaults.SetBool (SubmitTimesheet, SettingsNames.SubmitTimesheet.ToString ());
			NSUserDefaults.StandardUserDefaults.SetBool (AvailabilityRequired, SettingsNames.AvailabilityRequired.ToString ());
			NSUserDefaults.StandardUserDefaults.SetBool (AssignmentUpdated, SettingsNames.AssignmentUpdated.ToString ());
			NSUserDefaults.StandardUserDefaults.SetBool (AssignmentCanceled, SettingsNames.AssignmentCanceled.ToString ());
			NSUserDefaults.StandardUserDefaults.SetBool (AssignmentReminders, SettingsNames.AssignmentReminders.ToString ());
			NSUserDefaults.StandardUserDefaults.SetBool (AssignmentConfirmationRequired, SettingsNames.AssignmentConfirmationRequired.ToString ());
		}

		private void SetDefaults()
		{
			ConfirmAssignment = true;
			SubmitTimesheet = true;
			AvailabilityRequired = true;
			AssignmentUpdated = true;
			AssignmentCanceled = true;
			AssignmentReminders = true;
			AssignmentConfirmationRequired = true;
			Save ();
		}
	}
}

