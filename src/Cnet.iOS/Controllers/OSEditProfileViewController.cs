// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cnt.API;
using Cnt.API.Exceptions;
using Cnt.Web.API.Models;

namespace Cnet.iOS
{
	public partial class OSEditProfileViewController : UIViewController
	{
		#region Private Members

		private NSString DoneSegueName = new NSString ("Profile");
		private int addressCount = 1;
		private int maxAltAddressCount = 5;
		private UITextField
			altAddressTextField1, altLine2TextField1, altCity1, altState1, altZipCode1,
			altAddressTextField2, altLine2TextField2, altCity2, altState2, altZipCode2,
			altAddressTextField3, altLine2TextField3, altCity3, altState3, altZipCode3,
			altAddressTextField4, altLine2TextField4, altCity4, altState4, altZipCode4,
			altAddressTextField5, altLine2TextField5, altCity5, altState5, altZipCode5;
		private bool hasErrors;
		private List<string> mobileCarriers;
		private User user;

		#endregion

		public OSEditProfileViewController (IntPtr handle) : base (handle)
		{
		}

		#region Public Methods

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			LoadUser ();
			WireUpView ();
			RenderUser ();
			SetUpKeyboardNotifications ();
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == DoneSegueName)
				SubmitForm ();
			base.PrepareForSegue (segue, sender);
		}

		public override bool ShouldPerformSegue (string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier == DoneSegueName)
				return !hasErrors;

			return base.ShouldPerformSegue (segueIdentifier, sender);
		}

		#endregion

		#region Event Delegates

		partial void addAlternateAddressPressed (NSObject sender)
		{
			float frameAdjustment = 241.0f;
			List<UIView> adjustedViewsList = new List<UIView> {
				addAddressButton,
				emergencyContactLabel,
				emergencyContactTextField,
				ecPhoneTextField
			};

			// If we are at our max addresses, no longer show the add address button.
			if (addressCount >= maxAltAddressCount) {
				adjustedViewsList.Remove (addAddressButton);
				addAddressButton.Hidden = true;

				foreach (UIView view in adjustedViewsList) {
					view.AdjustFrame (0, (frameAdjustment - 51.0f), 0, 0);
				}

				// Adjust content size, not frame for scroll view
				SizeF scrollViewContent = editProfileScrollView.ContentSize;
				scrollViewContent.Height += frameAdjustment - 51.0f;
				editProfileScrollView.ContentSize = scrollViewContent;
			}
			else {
				foreach (UIView view in adjustedViewsList) {
					view.AdjustFrame (0, frameAdjustment, 0, 0);
				}

				// Adjust content size, not frame for scroll view
				SizeF scrollViewContent = editProfileScrollView.ContentSize;
				scrollViewContent.Height += frameAdjustment;
				editProfileScrollView.ContentSize = scrollViewContent;
			}

			// Add new ui elements for alternative address
			// Address Label
			UILabel altAddressLabel = new UILabel (addressLabel.Frame);
			altAddressLabel.AdjustFrame (0, frameAdjustment * addressCount, 100, 0);
			altAddressLabel.Text = "Alternate Address " + addressCount;
			altAddressLabel.Font = UIFont.FromName ("HelveticaNeue", 15f);
			altAddressLabel.TextColor = UIColor.DarkGray;
			editProfileScrollView.AddSubview (altAddressLabel);

			// Address text fields
			List<UITextField> altAddressElements;

			switch (addressCount) {
			case 1:
				altAddressElements = new List<UITextField> {
					(altAddressTextField1 = new UITextField (addressTextField.Frame)),
					(altLine2TextField1 = new UITextField (addressLine2TextField.Frame)),
					(altCity1 = new UITextField (cityTextField.Frame)),
					(altState1 = new UITextField (stateTextField.Frame)),
					(altZipCode1 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 2:
				altAddressElements = new List<UITextField> {
					(altAddressTextField2 = new UITextField (addressTextField.Frame)),
					(altLine2TextField2 = new UITextField (addressLine2TextField.Frame)),
					(altCity2 = new UITextField (cityTextField.Frame)),
					(altState2 = new UITextField (stateTextField.Frame)),
					(altZipCode2 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 3:
				altAddressElements = new List<UITextField> {
					(altAddressTextField3 = new UITextField (addressTextField.Frame)),
					(altLine2TextField3 = new UITextField (addressLine2TextField.Frame)),
					(altCity3 = new UITextField (cityTextField.Frame)),
					(altState3 = new UITextField (stateTextField.Frame)),
					(altZipCode3 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 4:
				altAddressElements = new List<UITextField> {
					(altAddressTextField4 = new UITextField (addressTextField.Frame)),
					(altLine2TextField4 = new UITextField (addressLine2TextField.Frame)),
					(altCity4 = new UITextField (cityTextField.Frame)),
					(altState4 = new UITextField (stateTextField.Frame)),
					(altZipCode4 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 5:
				altAddressElements = new List<UITextField> {
					(altAddressTextField5 = new UITextField (addressTextField.Frame)),
					(altLine2TextField5 = new UITextField (addressLine2TextField.Frame)),
					(altCity5 = new UITextField (cityTextField.Frame)),
					(altState5 = new UITextField (stateTextField.Frame)),
					(altZipCode5 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			default:
				break;
			}


			List<String> fieldPlaceHolderText = new List<String>{ "Address", "Address Line 2", "City", "State", "Zip Code" };
			for (int i = 0; i < altAddressElements.Count; i++) {
				altAddressElements [i].AdjustFrame (0, frameAdjustment * addressCount, 0, 0);
				altAddressElements [i].Background = new UIImage ("profile-fields.png");
				altAddressElements [i].AddPadding (10, 24);
				altAddressElements [i].Placeholder = fieldPlaceHolderText [i];
				altAddressElements [i].Font = UIFont.FromName ("HelveticaNeue", 15f);
				altAddressElements [i].TextColor = UIColor.DarkGray;
				editProfileScrollView.AddSubview (altAddressElements [i]);
			}

			addressCount++;
		}
		// Overload method for adding an alternate address
		private void addAlternateAddressPressed (Address address)
		{
			float frameAdjustment = 241.0f;
			List<UIView> adjustedViewsList = new List<UIView> {
				addAddressButton,
				emergencyContactLabel,
				emergencyContactTextField,
				ecPhoneTextField
			};

			foreach (UIView view in adjustedViewsList) {
				view.AdjustFrame (0, frameAdjustment, 0, 0);
			}

			// Adjust content size, not frame for scroll view
			SizeF scrollViewContent = editProfileScrollView.ContentSize;
			scrollViewContent.Height += frameAdjustment;
			editProfileScrollView.ContentSize = scrollViewContent;

			// Add new ui elements for alternative address
			// Address Label
			UILabel altAddressLabel = new UILabel (addressLabel.Frame);
			altAddressLabel.AdjustFrame (0, frameAdjustment * addressCount, 100, 0);
			altAddressLabel.Text = "Alternate Address " + addressCount;
			altAddressLabel.Font = UIFont.FromName ("HelveticaNeue", 15f);
			altAddressLabel.TextColor = UIColor.DarkGray;
			editProfileScrollView.AddSubview (altAddressLabel);

			// Address text fields
			List<UITextField> altAddressElements;

			switch (addressCount) {
			case 1:
				altAddressElements = new List<UITextField> {
					(altAddressTextField1 = new UITextField (addressTextField.Frame)),
					(altLine2TextField1 = new UITextField (addressLine2TextField.Frame)),
					(altCity1 = new UITextField (cityTextField.Frame)),
					(altState1 = new UITextField (stateTextField.Frame)),
					(altZipCode1 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 2:
				altAddressElements = new List<UITextField> {
					(altAddressTextField2 = new UITextField (addressTextField.Frame)),
					(altLine2TextField2 = new UITextField (addressLine2TextField.Frame)),
					(altCity2 = new UITextField (cityTextField.Frame)),
					(altState2 = new UITextField (stateTextField.Frame)),
					(altZipCode2 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 3:
				altAddressElements = new List<UITextField> {
					(altAddressTextField3 = new UITextField (addressTextField.Frame)),
					(altLine2TextField3 = new UITextField (addressLine2TextField.Frame)),
					(altCity3 = new UITextField (cityTextField.Frame)),
					(altState3 = new UITextField (stateTextField.Frame)),
					(altZipCode3 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 4:
				altAddressElements = new List<UITextField> {
					(altAddressTextField4 = new UITextField (addressTextField.Frame)),
					(altLine2TextField4 = new UITextField (addressLine2TextField.Frame)),
					(altCity4 = new UITextField (cityTextField.Frame)),
					(altState4 = new UITextField (stateTextField.Frame)),
					(altZipCode4 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			case 5:
				altAddressElements = new List<UITextField> {
					(altAddressTextField5 = new UITextField (addressTextField.Frame)),
					(altLine2TextField5 = new UITextField (addressLine2TextField.Frame)),
					(altCity5 = new UITextField (cityTextField.Frame)),
					(altState5 = new UITextField (stateTextField.Frame)),
					(altZipCode5 = new UITextField (zipCodeTextField.Frame))
				};
				break;

			default:
				break;
			}

			List<String> fieldPlaceHolderText = new List<String> { "Address", "Address Line 2", "City", "State", "Zip Code" };
			// Add values from passed address
			List<String> fieldValues = new List<String> {
				address.Line1,
				address.Line2,
				address.City,
				address.State,
				address.Zip
			};

			for (int i = 0; i < altAddressElements.Count; i++) {
				altAddressElements [i].AdjustFrame (0, frameAdjustment, 0, 0);
				altAddressElements [i].Background = new UIImage ("profile-fields.png");
				altAddressElements [i].AddPadding (10, 24);
				altAddressElements [i].Placeholder = fieldPlaceHolderText [i];
				altAddressElements [i].Text = fieldValues [i];
				altAddressElements [i].Font = UIFont.FromName ("HelveticaNeue", 15f);
				altAddressElements [i].TextColor = UIColor.DarkGray;
				editProfileScrollView.AddSubview (altAddressElements [i]);
			}

			addressCount++;
		}

		private void PhoneCarrierClick (object sender, EventArgs e)
		{
			ShowCarrierPicker ();
		}

		#endregion

		#region Private Methods

		private void LoadUser ()
		{
			try {
				Client client = AuthenticationHelper.GetClient ();
				mobileCarriers = new List<string> (client.MobileCarrierService.GetMobileCarriers ().OrderBy (c => c));
				user = client.UserService.GetUser (AuthenticationHelper.UserData.UserId);
			} catch (CntResponseException ex) {
				Utility.ShowError (ex);
			}
		}

		private void RenderUser ()
		{
			List<UITextField> textFieldList = new List<UITextField> {
				firstNameTextField,
				lastNameTextField,
				emailTextField,
				phoneTextField,
				homePhoneTextField,
				workPhoneTextField,
				schoolPhoneTextField,
				otherPhoneTextField,
				emergencyContactTextField,
				ecPhoneTextField
			};
			List<UITextField> addressFieldList = new List<UITextField> {
				addressTextField,
				addressLine2TextField,
				cityTextField, 
				stateTextField,
				zipCodeTextField
			};

			List<String> imageNameList = new List<String> {
				"icon-user.png",
				"icon-user.png",
				"icon-mail.png",
				"icon-mobile.png",
				"icon-phone.png",
				"icon-phone.png",
				"icon-phone.png",
				"icon-phone.png",
				"icon-user.png",
				"icon-phone.png"
			};

			// Indent text/set image in text views here
			for (int i = 0; i < textFieldList.Count; i++) {
				textFieldList [i].AddPadding (40, 24, new UIImage (imageNameList [i]));
			}

			// Indent text for address fields (no image)
			for (int i = 0; i < addressFieldList.Count; i++) {
				addressFieldList [i].AddPadding (10, 24);
			}

			profileImage.Image = user.GetProfileImage ();

			firstNameTextField.Text = user.FirstName;
			lastNameTextField.Text = user.LastName;
			emailTextField.Text = user.Email;
			phoneTextField.Text = user.MobilePhone;
			phoneCarrierLabel.Text = user.MobileCarrier;
			textMessageSwitch.On = user.AllowTexts;
			homePhoneTextField.Text = user.HomePhone;
			workPhoneTextField.Text = user.WorkPhone;
			schoolPhoneTextField.Text = user.SchoolPhone;
			otherPhoneTextField.Text = user.OtherPhone;

			addressTextField.Text = user.AddressCurrent.Line1;
			addressLine2TextField.Text = user.AddressCurrent.Line2;
			cityTextField.Text = user.AddressCurrent.City;
			stateTextField.Text = user.AddressCurrent.State;
			zipCodeTextField.Text = user.AddressCurrent.Zip;

			if (user.AddressAlternate1.AddressHasContents ()) {
				this.addAlternateAddressPressed (user.AddressAlternate1);
			}

			if (user.AddressAlternate2.AddressHasContents ()) {
				this.addAlternateAddressPressed (user.AddressAlternate2);
			}

			if (user.AddressAlternate3.AddressHasContents ()) {
				this.addAlternateAddressPressed (user.AddressAlternate3);
			}

			if (user.AddressAlternate4.AddressHasContents ()) {
				this.addAlternateAddressPressed (user.AddressAlternate4);
			}
			if (user.AddressAlternate5.AddressHasContents ()) {
				this.addAlternateAddressPressed (user.AddressAlternate5);
			}

			emergencyContactTextField.Text = user.EmergencyContactName;
			ecPhoneTextField.Text = user.EmergencyContactPhone;
		}

		private void ShowCarrierPicker ()
		{
			var actionSheetCarrierPicker = new ActionSheetListPicker (this.View);
			var pickerDataModel = new ListPickerViewModel<string> (mobileCarriers);
			actionSheetCarrierPicker.ListPicker.Source = pickerDataModel;
			actionSheetCarrierPicker.ListPicker.Select (mobileCarriers.IndexOf (phoneCarrierLabel.Text), 0, false);
			pickerDataModel.ValueChanged += (object sender, EventArgs e) => phoneCarrierLabel.Text = (sender as ListPickerViewModel<string>).SelectedItem;
			actionSheetCarrierPicker.Show ();
		}

		private void SubmitForm ()
		{
			user.FirstName = firstNameTextField.Text;
			user.LastName = lastNameTextField.Text;
			user.Email = emailTextField.Text;
			user.MobilePhone = phoneTextField.Text;
			user.MobileCarrier = phoneCarrierLabel.Text;
			user.AllowTexts = textMessageSwitch.On;
			user.HomePhone = homePhoneTextField.Text;
			user.WorkPhone = workPhoneTextField.Text;
			user.SchoolPhone = schoolPhoneTextField.Text;
			user.OtherPhone = otherPhoneTextField.Text;

			user.AddressCurrent.Line1 = addressTextField.Text;
			user.AddressCurrent.Line2 = addressLine2TextField.Text;
			user.AddressCurrent.City = cityTextField.Text;
			user.AddressCurrent.State = stateTextField.Text;
			user.AddressCurrent.Zip = zipCodeTextField.Text;

			if (addressCount > 1) {
				// Must be using at least one alternate address
				user.AddressAlternate1.Line1 = altAddressTextField1.Text;
				user.AddressAlternate1.Line2 = altLine2TextField1.Text;
				user.AddressAlternate1.City = altCity1.Text;
				user.AddressAlternate1.State = altState1.Text;
				user.AddressAlternate1.Zip = altZipCode1.Text;

				if (addressCount > 2) {
					user.AddressAlternate2.Line1 = altAddressTextField2.Text;
					user.AddressAlternate2.Line2 = altLine2TextField2.Text;
					user.AddressAlternate2.City = altCity2.Text;
					user.AddressAlternate2.State = altState2.Text;
					user.AddressAlternate2.Zip = altZipCode2.Text;
				}

				if (addressCount > 3) {
					user.AddressAlternate3.Line1 = altAddressTextField3.Text;
					user.AddressAlternate3.Line2 = altLine2TextField3.Text;
					user.AddressAlternate3.City = altCity3.Text;
					user.AddressAlternate3.State = altState3.Text;
					user.AddressAlternate3.Zip = altZipCode3.Text;
				}

				if (addressCount > 4) {
					user.AddressAlternate4.Line1 = altAddressTextField4.Text;
					user.AddressAlternate4.Line2 = altLine2TextField4.Text;
					user.AddressAlternate4.City = altCity4.Text;
					user.AddressAlternate4.State = altState4.Text;
					user.AddressAlternate4.Zip = altZipCode4.Text;
				}

				if (addressCount > 5) {
					user.AddressAlternate5.Line1 = altAddressTextField5.Text;
					user.AddressAlternate5.Line2 = altLine2TextField5.Text;
					user.AddressAlternate5.City = altCity5.Text;
					user.AddressAlternate5.State = altState5.Text;
					user.AddressAlternate5.Zip = altZipCode5.Text;
				}
			}

			user.EmergencyContactName = emergencyContactTextField.Text;
			user.EmergencyContactPhone = ecPhoneTextField.Text;

			try {
				Client client = AuthenticationHelper.GetClient ();
				client.UserService.UpdateUser (user);
				hasErrors = false;
			} catch (CntResponseException ex) {
				hasErrors = true;
				Utility.ShowError (ex);
			}
		}

		private void SetUpKeyboardNotifications ()
		{
			NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.DidShowNotification, KeyboardOpened);
			NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.DidHideNotification, KeyboardClosed);
		}

		private void KeyboardOpened (NSNotification notification)
		{
			System.Console.WriteLine ("Keyboard Opened");
			UIView activeView = KeyboardGetActiveView();
			if (activeView == null)
				return;

			var keyboardFrame = UIKeyboard.FrameBeginFromNotification (notification);
			var contentInsets = new UIEdgeInsets (0.0f, 0.0f, keyboardFrame.Height, 0.0f);

			editProfileScrollView.ContentInset = contentInsets;
			editProfileScrollView.ScrollIndicatorInsets = contentInsets;

			// Position of the active field relative inside the scroll view
			RectangleF relativeFrame = activeView.Superview.ConvertRectToView(activeView.Frame, editProfileScrollView);
			var spaceAboveKeyboard = editProfileScrollView.Frame.Height - keyboardFrame.Height;

			// Move the active field to the center of the available space
			var offset = relativeFrame.Y - (spaceAboveKeyboard - activeView.Frame.Height) / 2;
			editProfileScrollView.ContentOffset = new PointF(0, offset);
		}

		private void KeyboardClosed (NSNotification notification)
		{
			System.Console.WriteLine ("Keyboard Closed");
			editProfileScrollView.ContentInset = UIEdgeInsets.Zero;
			editProfileScrollView.ScrollIndicatorInsets = UIEdgeInsets.Zero;
		}

		private void WireUpView ()
		{
			phoneCarrierButton.TouchUpInside += PhoneCarrierClick;
		}

		protected virtual UIView KeyboardGetActiveView()
		{
			return this.View.FindFirstResponder();
		}

		#endregion
	}
}
