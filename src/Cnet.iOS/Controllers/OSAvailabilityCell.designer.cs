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
	[Register ("OSAvailabilityCell")]
	partial class OSAvailabilityCell
	{
		[Outlet]
		MonoTouch.UIKit.UIButton closeButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel datesLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel daysOfWeekLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel timesLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (closeButton != null) {
				closeButton.Dispose ();
				closeButton = null;
			}

			if (datesLabel != null) {
				datesLabel.Dispose ();
				datesLabel = null;
			}

			if (daysOfWeekLabel != null) {
				daysOfWeekLabel.Dispose ();
				daysOfWeekLabel = null;
			}

			if (timesLabel != null) {
				timesLabel.Dispose ();
				timesLabel = null;
			}
		}
	}
}
