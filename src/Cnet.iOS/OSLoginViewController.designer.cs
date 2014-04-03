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
	[Register ("OSLoginViewController")]
	partial class OSLoginViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField tbxPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField tbxUsername { get; set; }

		[Action ("loginButtonClick:")]
		partial void loginButtonClick (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tbxUsername != null) {
				tbxUsername.Dispose ();
				tbxUsername = null;
			}

			if (tbxPassword != null) {
				tbxPassword.Dispose ();
				tbxPassword = null;
			}
		}
	}
}
