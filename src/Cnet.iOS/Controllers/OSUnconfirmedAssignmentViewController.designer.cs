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
	[Register ("OSUnconfirmedAssignmentViewController")]
	partial class OSUnconfirmedAssignmentViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton actionButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton declineButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView detailTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel mapLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView mapLabelView { get; set; }

		[Outlet]
		MonoTouch.MapKit.MKMapView mapView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton messageCloseButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel messageLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView messageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton policyButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView policyView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (detailTable != null) {
				detailTable.Dispose ();
				detailTable = null;
			}

			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}

			if (mapLabelView != null) {
				mapLabelView.Dispose ();
				mapLabelView = null;
			}

			if (mapLabel != null) {
				mapLabel.Dispose ();
				mapLabel = null;
			}

			if (messageView != null) {
				messageView.Dispose ();
				messageView = null;
			}

			if (messageLabel != null) {
				messageLabel.Dispose ();
				messageLabel = null;
			}

			if (messageCloseButton != null) {
				messageCloseButton.Dispose ();
				messageCloseButton = null;
			}

			if (actionButton != null) {
				actionButton.Dispose ();
				actionButton = null;
			}

			if (declineButton != null) {
				declineButton.Dispose ();
				declineButton = null;
			}

			if (policyButton != null) {
				policyButton.Dispose ();
				policyButton = null;
			}

			if (policyView != null) {
				policyView.Dispose ();
				policyView = null;
			}
		}
	}
}
