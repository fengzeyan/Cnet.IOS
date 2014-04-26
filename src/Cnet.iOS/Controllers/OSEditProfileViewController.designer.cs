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
		MonoTouch.UIKit.UIButton addAddressButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel addressLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField addressLine2TextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField addressTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField cityTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField ecPhoneTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIScrollView editProfileScrollView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField emailTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel emergencyContactLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField emergencyContactTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField firstNameTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField homePhoneTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField lastNameTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField otherPhoneTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton phoneCarrierButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel phoneCarrierLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField phoneTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView profileImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField schoolPhoneTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField stateTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch textMessageSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField workPhoneTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField zipCodeTextField { get; set; }

		[Action ("addAlternateAddressPressed:")]
		partial void addAlternateAddressPressed (MonoTouch.Foundation.NSObject sender);

		[Action ("addNewPhonePressed:")]
		partial void addNewPhonePressed (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (addAddressButton != null) {
				addAddressButton.Dispose ();
				addAddressButton = null;
			}

			if (addressLabel != null) {
				addressLabel.Dispose ();
				addressLabel = null;
			}

			if (addressLine2TextField != null) {
				addressLine2TextField.Dispose ();
				addressLine2TextField = null;
			}

			if (addressTextField != null) {
				addressTextField.Dispose ();
				addressTextField = null;
			}

			if (cityTextField != null) {
				cityTextField.Dispose ();
				cityTextField = null;
			}

			if (ecPhoneTextField != null) {
				ecPhoneTextField.Dispose ();
				ecPhoneTextField = null;
			}

			if (editProfileScrollView != null) {
				editProfileScrollView.Dispose ();
				editProfileScrollView = null;
			}

			if (emailTextField != null) {
				emailTextField.Dispose ();
				emailTextField = null;
			}

			if (emergencyContactLabel != null) {
				emergencyContactLabel.Dispose ();
				emergencyContactLabel = null;
			}

			if (emergencyContactTextField != null) {
				emergencyContactTextField.Dispose ();
				emergencyContactTextField = null;
			}

			if (firstNameTextField != null) {
				firstNameTextField.Dispose ();
				firstNameTextField = null;
			}

			if (lastNameTextField != null) {
				lastNameTextField.Dispose ();
				lastNameTextField = null;
			}

			if (phoneCarrierButton != null) {
				phoneCarrierButton.Dispose ();
				phoneCarrierButton = null;
			}

			if (phoneCarrierLabel != null) {
				phoneCarrierLabel.Dispose ();
				phoneCarrierLabel = null;
			}

			if (phoneTextField != null) {
				phoneTextField.Dispose ();
				phoneTextField = null;
			}

			if (homePhoneTextField != null) {
				homePhoneTextField.Dispose ();
				homePhoneTextField = null;
			}

			if (workPhoneTextField != null) {
				workPhoneTextField.Dispose ();
				workPhoneTextField = null;
			}

			if (schoolPhoneTextField != null) {
				schoolPhoneTextField.Dispose ();
				schoolPhoneTextField = null;
			}

			if (otherPhoneTextField != null) {
				otherPhoneTextField.Dispose ();
				otherPhoneTextField = null;
			}

			if (profileImage != null) {
				profileImage.Dispose ();
				profileImage = null;
			}

			if (stateTextField != null) {
				stateTextField.Dispose ();
				stateTextField = null;
			}

			if (textMessageSwitch != null) {
				textMessageSwitch.Dispose ();
				textMessageSwitch = null;
			}

			if (zipCodeTextField != null) {
				zipCodeTextField.Dispose ();
				zipCodeTextField = null;
			}
		}
	}
}
