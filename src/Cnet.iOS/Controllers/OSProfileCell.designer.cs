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
	[Register ("OSProfileCell")]
	partial class OSProfileCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView iconImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView phoneIconImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel profileLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (profileLabel != null) {
				profileLabel.Dispose ();
				profileLabel = null;
			}

			if (iconImage != null) {
				iconImage.Dispose ();
				iconImage = null;
			}

			if (phoneIconImage != null) {
				phoneIconImage.Dispose ();
				phoneIconImage = null;
			}
		}
	}
}
