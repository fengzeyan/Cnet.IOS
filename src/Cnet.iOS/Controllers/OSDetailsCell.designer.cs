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
	[Register ("OSDetailsCell")]
	partial class OSDetailsCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel importantDetailsHeaderLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel importantDetailsLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel orderNotesHeaderLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel orderNotesLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (orderNotesHeaderLabel != null) {
				orderNotesHeaderLabel.Dispose ();
				orderNotesHeaderLabel = null;
			}

			if (orderNotesLabel != null) {
				orderNotesLabel.Dispose ();
				orderNotesLabel = null;
			}

			if (importantDetailsHeaderLabel != null) {
				importantDetailsHeaderLabel.Dispose ();
				importantDetailsHeaderLabel = null;
			}

			if (importantDetailsLabel != null) {
				importantDetailsLabel.Dispose ();
				importantDetailsLabel = null;
			}
		}
	}
}
