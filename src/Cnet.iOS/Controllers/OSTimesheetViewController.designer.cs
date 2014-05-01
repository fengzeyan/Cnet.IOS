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
	[Register ("OSTimesheetViewController")]
	partial class OSTimesheetViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel currentPayPeriodLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton messagesButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel messagesLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView timesheetsTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (currentPayPeriodLabel != null) {
				currentPayPeriodLabel.Dispose ();
				currentPayPeriodLabel = null;
			}

			if (messagesLabel != null) {
				messagesLabel.Dispose ();
				messagesLabel = null;
			}

			if (messagesButton != null) {
				messagesButton.Dispose ();
				messagesButton = null;
			}

			if (timesheetsTable != null) {
				timesheetsTable.Dispose ();
				timesheetsTable = null;
			}
		}
	}
}
