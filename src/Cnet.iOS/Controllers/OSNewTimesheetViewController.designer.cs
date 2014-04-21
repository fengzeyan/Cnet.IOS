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
	[Register ("OSNewTimesheetViewController")]
	partial class OSNewTimesheetViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton actionButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton endButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel endLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton endTimeDownButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel endTimeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton endTimeUpButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView recapTextView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem resetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton startButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel startLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton startTimeDownButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel startTimeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton startTimeUpButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (resetButton != null) {
				resetButton.Dispose ();
				resetButton = null;
			}

			if (startButton != null) {
				startButton.Dispose ();
				startButton = null;
			}

			if (startLabel != null) {
				startLabel.Dispose ();
				startLabel = null;
			}

			if (endButton != null) {
				endButton.Dispose ();
				endButton = null;
			}

			if (endLabel != null) {
				endLabel.Dispose ();
				endLabel = null;
			}

			if (recapTextView != null) {
				recapTextView.Dispose ();
				recapTextView = null;
			}

			if (startTimeUpButton != null) {
				startTimeUpButton.Dispose ();
				startTimeUpButton = null;
			}

			if (startTimeDownButton != null) {
				startTimeDownButton.Dispose ();
				startTimeDownButton = null;
			}

			if (startTimeLabel != null) {
				startTimeLabel.Dispose ();
				startTimeLabel = null;
			}

			if (endTimeUpButton != null) {
				endTimeUpButton.Dispose ();
				endTimeUpButton = null;
			}

			if (endTimeDownButton != null) {
				endTimeDownButton.Dispose ();
				endTimeDownButton = null;
			}

			if (endTimeLabel != null) {
				endTimeLabel.Dispose ();
				endTimeLabel = null;
			}

			if (actionButton != null) {
				actionButton.Dispose ();
				actionButton = null;
			}
		}
	}
}
