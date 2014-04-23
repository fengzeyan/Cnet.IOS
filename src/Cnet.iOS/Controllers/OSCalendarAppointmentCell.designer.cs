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
	[Register ("OSCalendarAppointmentCell")]
	partial class OSCalendarAppointmentCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel endTimeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel endTimePmLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel familyNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView flagImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView profileBorderImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView profileImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel startTimeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel startTimePmLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView statusImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel statusLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (profileImage != null) {
				profileImage.Dispose ();
				profileImage = null;
			}

			if (profileBorderImage != null) {
				profileBorderImage.Dispose ();
				profileBorderImage = null;
			}

			if (endTimeLabel != null) {
				endTimeLabel.Dispose ();
				endTimeLabel = null;
			}

			if (endTimePmLabel != null) {
				endTimePmLabel.Dispose ();
				endTimePmLabel = null;
			}

			if (familyNameLabel != null) {
				familyNameLabel.Dispose ();
				familyNameLabel = null;
			}

			if (flagImage != null) {
				flagImage.Dispose ();
				flagImage = null;
			}

			if (startTimeLabel != null) {
				startTimeLabel.Dispose ();
				startTimeLabel = null;
			}

			if (startTimePmLabel != null) {
				startTimePmLabel.Dispose ();
				startTimePmLabel = null;
			}

			if (statusImage != null) {
				statusImage.Dispose ();
				statusImage = null;
			}

			if (statusLabel != null) {
				statusLabel.Dispose ();
				statusLabel = null;
			}
		}
	}
}
