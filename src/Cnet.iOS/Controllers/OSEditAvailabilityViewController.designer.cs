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
	[Register ("OSEditAvailabilityViewController")]
	partial class OSEditAvailabilityViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton actionButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton addTimeBlockButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView availabillityTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton deleteButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem editButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (availabillityTable != null) {
				availabillityTable.Dispose ();
				availabillityTable = null;
			}

			if (actionButton != null) {
				actionButton.Dispose ();
				actionButton = null;
			}

			if (addTimeBlockButton != null) {
				addTimeBlockButton.Dispose ();
				addTimeBlockButton = null;
			}

			if (deleteButton != null) {
				deleteButton.Dispose ();
				deleteButton = null;
			}

			if (editButton != null) {
				editButton.Dispose ();
				editButton = null;
			}
		}
	}
}
