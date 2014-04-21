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
	[Register ("OSFamilyCell")]
	partial class OSFamilyCell
	{
		[Outlet]
		MonoTouch.UIKit.UIButton callButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel familyNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView infoImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView profileImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel statusLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (profileImage != null) {
				profileImage.Dispose ();
				profileImage = null;
			}

			if (infoImage != null) {
				infoImage.Dispose ();
				infoImage = null;
			}

			if (familyNameLabel != null) {
				familyNameLabel.Dispose ();
				familyNameLabel = null;
			}

			if (statusLabel != null) {
				statusLabel.Dispose ();
				statusLabel = null;
			}

			if (callButton != null) {
				callButton.Dispose ();
				callButton = null;
			}
		}
	}
}
