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
		MonoTouch.UIKit.UIButton nextAssignmentButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton nextAssignmentCallButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nextAssignmentDateLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nextAssignmentEndLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nextAssignmentEndPmLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nextAssignmentFamilyLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton nextAssignmentMapButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nextAssignmentStartLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nextAssignmentStartPmLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView nextAssignmentView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView noAssignmentsImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton upcomingButton { get; set; }

		[Action ("completedSwitchPressed:")]
		partial void completedSwitchPressed (MonoTouch.UIKit.UIButton sender);

		[Action ("upcomingSwitchPressed:")]
		partial void upcomingSwitchPressed (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (noAssignmentsImage != null) {
				noAssignmentsImage.Dispose ();
				noAssignmentsImage = null;
			}

			if (assignmentsTable != null) {
				assignmentsTable.Dispose ();
				assignmentsTable = null;
			}

			if (completedButton != null) {
				completedButton.Dispose ();
				completedButton = null;
			}

			if (nextAssignmentView != null) {
				nextAssignmentView.Dispose ();
				nextAssignmentView = null;
			}

			if (nextAssignmentButton != null) {
				nextAssignmentButton.Dispose ();
				nextAssignmentButton = null;
			}

			if (nextAssignmentCallButton != null) {
				nextAssignmentCallButton.Dispose ();
				nextAssignmentCallButton = null;
			}

			if (nextAssignmentDateLabel != null) {
				nextAssignmentDateLabel.Dispose ();
				nextAssignmentDateLabel = null;
			}

			if (nextAssignmentEndLabel != null) {
				nextAssignmentEndLabel.Dispose ();
				nextAssignmentEndLabel = null;
			}

			if (nextAssignmentEndPmLabel != null) {
				nextAssignmentEndPmLabel.Dispose ();
				nextAssignmentEndPmLabel = null;
			}

			if (nextAssignmentFamilyLabel != null) {
				nextAssignmentFamilyLabel.Dispose ();
				nextAssignmentFamilyLabel = null;
			}

			if (nextAssignmentMapButton != null) {
				nextAssignmentMapButton.Dispose ();
				nextAssignmentMapButton = null;
			}

			if (nextAssignmentStartLabel != null) {
				nextAssignmentStartLabel.Dispose ();
				nextAssignmentStartLabel = null;
			}

			if (nextAssignmentStartPmLabel != null) {
				nextAssignmentStartPmLabel.Dispose ();
				nextAssignmentStartPmLabel = null;
			}

			if (upcomingButton != null) {
				upcomingButton.Dispose ();
				upcomingButton = null;
			}
		}
	}
}
