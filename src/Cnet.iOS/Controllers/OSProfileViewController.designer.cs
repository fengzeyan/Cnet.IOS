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
	[Register ("OSProfileViewController")]
	partial class OSProfileViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel addressLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel assignmentsLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nextAssignmentLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel phoneLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView profileTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel timesheetsLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (profileTable != null) {
				profileTable.Dispose ();
				profileTable = null;
			}

			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}

			if (addressLabel != null) {
				addressLabel.Dispose ();
				addressLabel = null;
			}

			if (phoneLabel != null) {
				phoneLabel.Dispose ();
				phoneLabel = null;
			}

			if (assignmentsLabel != null) {
				assignmentsLabel.Dispose ();
				assignmentsLabel = null;
			}

			if (timesheetsLabel != null) {
				timesheetsLabel.Dispose ();
				timesheetsLabel = null;
			}

			if (nextAssignmentLabel != null) {
				nextAssignmentLabel.Dispose ();
				nextAssignmentLabel = null;
			}
		}
	}
}
