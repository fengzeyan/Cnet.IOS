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
		MonoTouch.UIKit.UILabel emailLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel faxLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel phoneLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}

			if (addressLabel != null) {
				addressLabel.Dispose ();
				addressLabel = null;
			}

			if (phoneLabel != null) {
				phoneLabel.Dispose ();
				phoneLabel = null;
			}

			if (faxLabel != null) {
				faxLabel.Dispose ();
				faxLabel = null;
			}

			if (emailLabel != null) {
				emailLabel.Dispose ();
				emailLabel = null;
			}
		}
	}
}
