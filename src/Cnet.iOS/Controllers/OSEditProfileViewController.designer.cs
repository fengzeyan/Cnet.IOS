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
	[Register ("OSEditProfileViewController")]
	partial class OSEditProfileViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField addressLine2TextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField addressTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField cityTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField emailTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField firstNameTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField lastNameTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField phoneTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField stateTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField zipCodeTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (firstNameTextField != null) {
				firstNameTextField.Dispose ();
				firstNameTextField = null;
			}

			if (lastNameTextField != null) {
				lastNameTextField.Dispose ();
				lastNameTextField = null;
			}

			if (emailTextField != null) {
				emailTextField.Dispose ();
				emailTextField = null;
			}

			if (phoneTextField != null) {
				phoneTextField.Dispose ();
				phoneTextField = null;
			}

			if (addressTextField != null) {
				addressTextField.Dispose ();
				addressTextField = null;
			}

			if (addressLine2TextField != null) {
				addressLine2TextField.Dispose ();
				addressLine2TextField = null;
			}

			if (cityTextField != null) {
				cityTextField.Dispose ();
				cityTextField = null;
			}

			if (stateTextField != null) {
				stateTextField.Dispose ();
				stateTextField = null;
			}

			if (zipCodeTextField != null) {
				zipCodeTextField.Dispose ();
				zipCodeTextField = null;
			}
		}
	}
}
