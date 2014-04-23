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
	[Register ("OSCalendarInfoCell")]
	partial class OSCalendarInfoCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel dateLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel timeLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (dateLabel != null) {
				dateLabel.Dispose ();
				dateLabel = null;
			}

			if (timeLabel != null) {
				timeLabel.Dispose ();
				timeLabel = null;
			}
		}
	}
}
