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
	[Register ("OSAvailabilityTimesCell")]
	partial class OSAvailabilityTimesCell
	{
		[Outlet]
		MonoTouch.UIKit.UIButton endTimeButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton endTimeDownButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel endTimeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton endTimeUpButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton startTimeButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton startTimeDownButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel startTimeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton startTimeUpButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (endTimeButton != null) {
				endTimeButton.Dispose ();
				endTimeButton = null;
			}

			if (endTimeDownButton != null) {
				endTimeDownButton.Dispose ();
				endTimeDownButton = null;
			}

			if (endTimeLabel != null) {
				endTimeLabel.Dispose ();
				endTimeLabel = null;
			}

			if (endTimeUpButton != null) {
				endTimeUpButton.Dispose ();
				endTimeUpButton = null;
			}

			if (startTimeButton != null) {
				startTimeButton.Dispose ();
				startTimeButton = null;
			}

			if (startTimeDownButton != null) {
				startTimeDownButton.Dispose ();
				startTimeDownButton = null;
			}

			if (startTimeLabel != null) {
				startTimeLabel.Dispose ();
				startTimeLabel = null;
			}

			if (startTimeUpButton != null) {
				startTimeUpButton.Dispose ();
				startTimeUpButton = null;
			}
		}
	}
}
