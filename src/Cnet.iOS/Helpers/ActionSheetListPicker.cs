using System;
using System.Drawing;
using MonoTouch.UIKit;

namespace Cnet.iOS
{
	public class ActionSheetListPicker
	{
		#region Private Members
		private UIActionSheet actionSheet;
		private UIButton doneButton = UIButton.FromType (UIButtonType.RoundedRect);
		private UIView owner;
		private UILabel titleLabel = new UILabel ();
		#endregion

		#region Public Properties
		/// <summary>
		/// Set any picker properties here
		/// </summary>
		public UIPickerView ListPicker
		{
			get { return listPicker; }
			set { listPicker = value; }
		}
		UIPickerView listPicker = new UIPickerView(RectangleF.Empty);

		/// <summary>
		/// The title that shows up for the date picker
		/// </summary>
		public string Title
		{
			get { return titleLabel.Text; }
			set { titleLabel.Text = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ActionSheetListPicker (UIView owner)
		{
			// save our uiview owner
			this.owner = owner;

			// configure the title label
			titleLabel.BackgroundColor = UIColor.Clear;
			titleLabel.TextColor = UIColor.LightTextColor;
			titleLabel.Font = UIFont.BoldSystemFontOfSize (18);

			// configure the done button
			doneButton.SetTitle ("done", UIControlState.Normal);
			doneButton.TouchUpInside += (s, e) => { actionSheet.DismissWithClickedButtonIndex (0, true); };

			// create + configure the action sheet
			actionSheet = new UIActionSheet () { Style = UIActionSheetStyle.BlackTranslucent };
			actionSheet.Clicked += (s, e) => { Console.WriteLine ("Clicked on item {0}", e.ButtonIndex); };

			// add our controls to the action sheet
			actionSheet.AddSubview (listPicker);
			actionSheet.AddSubview (titleLabel);
			actionSheet.AddSubview (doneButton);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Shows the action sheet picker from the view that was set as the owner.
		/// </summary>
		public void Show ()
		{
			// declare vars
			float titleBarHeight = 40;
			SizeF doneButtonSize = new SizeF (71, 30);
			SizeF actionSheetSize = new SizeF (owner.Frame.Width, listPicker.Frame.Height + titleBarHeight);
			RectangleF actionSheetFrame = new RectangleF (0, owner.Frame.Height - actionSheetSize.Height
				, actionSheetSize.Width, actionSheetSize.Height);

			// show the action sheet and add the controls to it
			actionSheet.ShowInView (owner);

			// resize the action sheet to fit our other stuff
			actionSheet.Frame = actionSheetFrame;

			// move our picker to be at the bottom of the actionsheet (view coords are relative to the action sheet)
			listPicker.Frame = new RectangleF 
				(listPicker.Frame.X, titleBarHeight, listPicker.Frame.Width, listPicker.Frame.Height);

			// move our label to the top of the action sheet
			titleLabel.Frame = new RectangleF (10, 4, owner.Frame.Width - 100, 35);

			// move our button
			doneButton.Frame = new RectangleF (actionSheetSize.Width - doneButtonSize.Width - 10, 7, doneButtonSize.Width, doneButtonSize.Height);
		}

		/// <summary>
		/// Dismisses the action sheet date picker
		/// </summary>
		public void Hide (bool animated)
		{
			actionSheet.DismissWithClickedButtonIndex (0, animated);
		}
		#endregion
	}
}

