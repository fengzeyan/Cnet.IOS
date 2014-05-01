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
	[Register ("OSNotificationsCell")]
	partial class OSNotificationsCell
	{
		[Outlet]
		MonoTouch.UIKit.UIButton closeButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel familyNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView infoImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel infoLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView profileImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel statusLabel { get; set; }

		[Action ("closeButtonClicked:")]
		partial void closeButtonClicked (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (closeButton != null) {
				closeButton.Dispose ();
				closeButton = null;
			}

			if (familyNameLabel != null) {
				familyNameLabel.Dispose ();
				familyNameLabel = null;
			}

			if (infoImage != null) {
				infoImage.Dispose ();
				infoImage = null;
			}

			if (infoLabel != null) {
				infoLabel.Dispose ();
				infoLabel = null;
			}

			if (profileImage != null) {
				profileImage.Dispose ();
				profileImage = null;
			}

			if (statusLabel != null) {
				statusLabel.Dispose ();
				statusLabel = null;
			}
		}
	}
}
