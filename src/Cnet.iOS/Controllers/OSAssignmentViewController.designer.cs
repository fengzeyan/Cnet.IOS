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
	[Register ("OSAssignmentViewController")]
	partial class OSAssignmentViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton completedButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton messageButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton upcomingButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (upcomingButton != null) {
				upcomingButton.Dispose ();
				upcomingButton = null;
			}

			if (completedButton != null) {
				completedButton.Dispose ();
				completedButton = null;
			}

			if (messageButton != null) {
				messageButton.Dispose ();
				messageButton = null;
			}
		}
	}
}
