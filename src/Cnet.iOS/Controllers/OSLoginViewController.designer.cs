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
		MonoTouch.UIKit.UIButton forgotPasswordButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton signUpButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField tbxPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField tbxUsername { get; set; }

		[Action ("loginButtonClick:")]
		partial void loginButtonClick (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tbxPassword != null) {
				tbxPassword.Dispose ();
				tbxPassword = null;
			}

			if (tbxUsername != null) {
				tbxUsername.Dispose ();
				tbxUsername = null;
			}

			if (forgotPasswordButton != null) {
				forgotPasswordButton.Dispose ();
				forgotPasswordButton = null;
			}

			if (signUpButton != null) {
				signUpButton.Dispose ();
				signUpButton = null;
			}
		}
	}
}
