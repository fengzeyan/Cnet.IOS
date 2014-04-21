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
	[Register ("OSTimesheetCell")]
	partial class OSTimesheetCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView checkImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel dayLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel familyNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView iconClockImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel monthLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView profileImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel timesLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (checkImage != null) {
				checkImage.Dispose ();
				checkImage = null;
			}

			if (profileImage != null) {
				profileImage.Dispose ();
				profileImage = null;
			}

			if (dayLabel != null) {
				dayLabel.Dispose ();
				dayLabel = null;
			}

			if (monthLabel != null) {
				monthLabel.Dispose ();
				monthLabel = null;
			}

			if (familyNameLabel != null) {
				familyNameLabel.Dispose ();
				familyNameLabel = null;
			}

			if (iconClockImage != null) {
				iconClockImage.Dispose ();
				iconClockImage = null;
			}

			if (timesLabel != null) {
				timesLabel.Dispose ();
				timesLabel = null;
			}
		}
	}
}
