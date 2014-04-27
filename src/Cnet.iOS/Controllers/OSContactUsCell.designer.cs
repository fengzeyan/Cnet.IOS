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
	[Register ("OSContactUsCell")]
	partial class OSContactUsCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel addressLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton emailButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel faxLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton phoneButton { get; set; }

		[Action ("emailClicked:")]
		partial void emailClicked (MonoTouch.UIKit.UIButton sender);

		[Action ("phoneClicked:")]
		partial void phoneClicked (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (addressLabel != null) {
				addressLabel.Dispose ();
				addressLabel = null;
			}

			if (emailButton != null) {
				emailButton.Dispose ();
				emailButton = null;
			}

			if (faxLabel != null) {
				faxLabel.Dispose ();
				faxLabel = null;
			}

			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}

			if (phoneButton != null) {
				phoneButton.Dispose ();
				phoneButton = null;
			}
		}
	}
}
