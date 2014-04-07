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
	[Register ("OSAssignmentViewController")]
	partial class OSAssignmentViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView assignmentsTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton completedButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton upcomingButton { get; set; }

		[Action ("completedSwitchPressed:")]
		partial void completedSwitchPressed (MonoTouch.UIKit.UIButton sender);

		[Action ("upcomingSwitchPressed:")]
		partial void upcomingSwitchPressed (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (assignmentsTable != null) {
				assignmentsTable.Dispose ();
				assignmentsTable = null;
			}

			if (upcomingButton != null) {
				upcomingButton.Dispose ();
				upcomingButton = null;
			}

			if (completedButton != null) {
				completedButton.Dispose ();
				completedButton = null;
			}
		}
	}
}
