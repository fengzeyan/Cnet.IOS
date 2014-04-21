// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Cnet.iOS
{
	[Register ("OSSettingsViewController")]
	partial class OSSettingsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UISwitch assignmentCanceledSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch assignmentConfirmationRequiredSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch assignmentRemindersSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch assignmentUpdatedSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch availabilityRequiredSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch confirmAssignmentSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton rateAppButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch submitTimesheetSwitch { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (confirmAssignmentSwitch != null) {
				confirmAssignmentSwitch.Dispose ();
				confirmAssignmentSwitch = null;
			}

			if (submitTimesheetSwitch != null) {
				submitTimesheetSwitch.Dispose ();
				submitTimesheetSwitch = null;
			}

			if (availabilityRequiredSwitch != null) {
				availabilityRequiredSwitch.Dispose ();
				availabilityRequiredSwitch = null;
			}

			if (assignmentUpdatedSwitch != null) {
				assignmentUpdatedSwitch.Dispose ();
				assignmentUpdatedSwitch = null;
			}

			if (assignmentCanceledSwitch != null) {
				assignmentCanceledSwitch.Dispose ();
				assignmentCanceledSwitch = null;
			}

			if (assignmentRemindersSwitch != null) {
				assignmentRemindersSwitch.Dispose ();
				assignmentRemindersSwitch = null;
			}

			if (assignmentConfirmationRequiredSwitch != null) {
				assignmentConfirmationRequiredSwitch.Dispose ();
				assignmentConfirmationRequiredSwitch = null;
			}

			if (rateAppButton != null) {
				rateAppButton.Dispose ();
				rateAppButton = null;
			}
		}
	}
}
