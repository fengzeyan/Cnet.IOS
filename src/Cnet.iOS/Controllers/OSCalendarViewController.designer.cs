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
	[Register ("OSCalendarViewController")]
	partial class OSCalendarViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView calendarTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (calendarTable != null) {
				calendarTable.Dispose ();
				calendarTable = null;
			}
		}
	}
}
