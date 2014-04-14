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
	[Register ("OSStartEndCell")]
	partial class OSStartEndCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel endLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel startLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (startLabel != null) {
				startLabel.Dispose ();
				startLabel = null;
			}

			if (endLabel != null) {
				endLabel.Dispose ();
				endLabel = null;
			}
		}
	}
}
