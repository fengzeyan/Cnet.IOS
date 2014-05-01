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
	[Register ("OSNotificationsViewController")]
	partial class OSNotificationsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton closeButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel messagesLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView notificationsTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (notificationsTable != null) {
				notificationsTable.Dispose ();
				notificationsTable = null;
			}

			if (closeButton != null) {
				closeButton.Dispose ();
				closeButton = null;
			}

			if (messagesLabel != null) {
				messagesLabel.Dispose ();
				messagesLabel = null;
			}
		}
	}
}
