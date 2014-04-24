// This file has been autogenerated from a class added in the UI designer.

using System;

using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cnt.API;
using Cnt.API.Exceptions;
using Cnt.Web.API.Models;

namespace Cnet.iOS
{
	public partial class OSEditAvailabilityViewController : UIViewController
	{
		#region Private Members
		private static NSString availabilityBlockListSegueName = new NSString ("AvailabilityBlockList");
		private const string dateFormat = "ddd, MMM d, yyyy";
		private const string timeFormat = "h:mm tt";
		private AvailabilityBlock availabilityBlock;
		private List<string> weekDays;
		private bool hasErrors;
		#endregion

		public int AvailabilityBlockId { get; set; }

		public OSEditAvailabilityViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			LoadAvailabilityBlock ();
			WireUpView ();
			RenderAvailabilityBlock ();
		}

		#region Event Delegates
		private void ActionButtonClicked (object sender, EventArgs e)
		{
			SubmitForm ();
			if (!hasErrors)
				PerformSegue (availabilityBlockListSegueName, this);
		}

		private void DeleteButtonClicked (object sender, EventArgs e)
		{
			UIAlertView alert = new UIAlertView ("Delete Availability", "Are you sure you want to delete this availability?", null, "Cancel", "Confirm");
			alert.Clicked += DeleteConfirmClicked;
			alert.Show ();
		}

		private void DeleteConfirmClicked (object sender, UIButtonEventArgs e)
		{
			if (e.ButtonIndex == 1) {
				DeleteAvailabilityBlock ();
				if (!hasErrors)
					PerformSegue (availabilityBlockListSegueName, this);
			}
		}

		private void EndButtonClicked (object sender, EventArgs e)
		{
			ShowDatePicker (availabilityBlock.End.HasValue ? availabilityBlock.End.Value : DateTime.Now, UIDatePickerMode.Date, (object s, EventArgs ev) => {
				DateTime date = DateTime.SpecifyKind ((s as UIDatePicker).Date, DateTimeKind.Unspecified);
				availabilityBlock.End = date;
				endLabel.Text = date.ToString (dateFormat);
			});
		}

		private void EndTimeClicked (object sender, EventArgs e)
		{
			ShowDatePicker (availabilityBlock.End.HasValue ? availabilityBlock.End.Value : DateTime.Now, UIDatePickerMode.Time, (object s, EventArgs ev) => {
				DateTime date = DateTime.SpecifyKind ((s as UIDatePicker).Date, DateTimeKind.Unspecified);
				TimeSpan time = new TimeSpan (date.Hour, date.Minute, date.Second);
				TimeBlock timeBlock = availabilityBlock.Times.First ();
				availabilityBlock.Times.First().Duration = timeBlock.Start + (int)time.TotalSeconds;
				endTimeLabel.Text = date.ToString (timeFormat);
			});
		}

		private void EndTimeDownClicked (object sender, EventArgs e)
		{
			DateTime date = DateTime.ParseExact (endTimeLabel.Text, timeFormat, null).AddMinutes (-15);
			TimeSpan time = new TimeSpan (date.Hour, date.Minute, date.Second);
			TimeBlock timeBlock = availabilityBlock.Times.First ();
			availabilityBlock.Times.First().Duration = timeBlock.Start + (int)time.TotalSeconds;
			endTimeLabel.Text = date.ToString (timeFormat);
		}

		private void EndTimeUpClicked (object sender, EventArgs e)
		{
			DateTime date = DateTime.ParseExact (endTimeLabel.Text, timeFormat, null).AddMinutes (15);
			TimeSpan time = new TimeSpan (date.Hour, date.Minute, date.Second);
			TimeBlock timeBlock = availabilityBlock.Times.First ();
			availabilityBlock.Times.First().Duration = timeBlock.Start + (int)time.TotalSeconds;
			endTimeLabel.Text = date.ToString (timeFormat);
		}

		private void StartButtonClicked (object sender, EventArgs e)
		{
			ShowDatePicker (availabilityBlock.Start, UIDatePickerMode.Date, (object s, EventArgs ev) => {
				DateTime date = DateTime.SpecifyKind ((s as UIDatePicker).Date, DateTimeKind.Unspecified);
				availabilityBlock.Start = date;
				startLabel.Text = date.ToString (dateFormat);
			});
		}

		private void StartTimeClicked (object sender, EventArgs e)
		{
			ShowDatePicker (availabilityBlock.Start, UIDatePickerMode.Time, (object s, EventArgs ev) => {
				DateTime date = DateTime.SpecifyKind ((s as UIDatePicker).Date, DateTimeKind.Unspecified);
				TimeSpan time = new TimeSpan (date.Hour, date.Minute, date.Second);
				availabilityBlock.Times.First().Start = (int)time.TotalSeconds;
				startTimeLabel.Text = date.ToString (timeFormat);
			});
		}

		private void StartTimeDownClicked (object sender, EventArgs e)
		{
			DateTime date = DateTime.ParseExact (startTimeLabel.Text, timeFormat, null).AddMinutes (-15);
			TimeSpan time = new TimeSpan (date.Hour, date.Minute, date.Second);
			availabilityBlock.Times.First().Start = (int)time.TotalSeconds;
			availabilityBlock.Times.First ().Duration += (int)TimeSpan.FromMinutes (15).TotalSeconds;
			startTimeLabel.Text = date.ToString (timeFormat);
		}

		private void StartTimeUpClicked (object sender, EventArgs e)
		{
			DateTime date = DateTime.ParseExact (startTimeLabel.Text, timeFormat, null).AddMinutes (15);
			TimeSpan time = new TimeSpan (date.Hour, date.Minute, date.Second);
			availabilityBlock.Times.First().Start = (int)time.TotalSeconds;
			availabilityBlock.Times.First ().Duration -= (int)TimeSpan.FromMinutes (15).TotalSeconds;
			startTimeLabel.Text = date.ToString (timeFormat);
		}

		private void WeekDayClicked (string weekDay, UIButton sender)
		{
			if (weekDays.Contains (weekDay)) {
				weekDays.Remove (weekDay);
				sender.SetTitleColor (Utility.DisabledTextColor, UIControlState.Normal);
			} else {
				weekDays.Add (weekDay);
				sender.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
			}
			availabilityBlock.Weekdays = String.Join (", ", weekDays);
		}
		#endregion

		#region Private Methods
		private void DeleteAvailabilityBlock ()
		{
			try {
				Client client = AuthenticationHelper.GetClient ();
				client.AvailabilityService.DeleteAvailabilityBlock (AvailabilityBlockId);
				hasErrors = false;
			} catch (CntResponseException ex) {
				hasErrors = true;
				Utility.ShowError (ex);
			}
		}

		private void LoadAvailabilityBlock ()
		{
			Client client = AuthenticationHelper.GetClient ();
			availabilityBlock = client.AvailabilityService.GetAvailabilityBlock (AvailabilityBlockId);
			string weekDaysString = availabilityBlock.Weekdays
				.Replace ("Weekdays", "Monday, Tuesday, Wednesday, Thursday, Friday")
				.Replace ("Weekend", "Sunday, Saturday")
				.Replace ("All", "Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday");
			weekDays = new List<string> (Array.ConvertAll (weekDaysString.Split (new char[]{ ',' }, StringSplitOptions.RemoveEmptyEntries), p => p.Trim ()));

			if (availabilityBlock.Times == null || availabilityBlock.Times.Count () == 0) {
				availabilityBlock.Times = new List<TimeBlock> (new TimeBlock[]{ new TimeBlock () });
			}
		}

		private void RenderAvailabilityBlock ()
		{
			startLabel.Text = availabilityBlock.Start.ToString (dateFormat);
			endLabel.Text = availabilityBlock.End.HasValue ? availabilityBlock.End.Value.ToString (dateFormat) : "--";

			TimeBlock time = availabilityBlock.Times.First ();
			DateTime startTime = DateTime.Today.AddSeconds (time.Start);
			startTimeLabel.Text = startTime.ToString (timeFormat);
			endTimeLabel.Text = startTime.AddSeconds (time.Duration).ToString (timeFormat);

			foreach (string weekDay in weekDays) {
				switch (weekDay) {
				case "Sunday":
					sundayButton.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
					break;
				case "Monday":
					mondayButton.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
					break;
				case "Tuesday":
					tuesdayButton.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
					break;
				case "Wednesday":
					wednesdayButton.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
					break;
				case "Thursday":
					thursdayButton.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
					break;
				case "Friday":
					fridayButton.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
					break;
				case "Saturday":
					saturdayButton.SetTitleColor (Utility.NewTextColor, UIControlState.Normal);
					break;
				}
			}
		}

		private void ShowDatePicker(DateTime date, UIDatePickerMode mode, EventHandler valueChangedHandler)
		{
			var actionSheetDatePicker = new ActionSheetDatePicker (this.View);
			NSDate nsDate = (NSDate)DateTime.SpecifyKind (date, DateTimeKind.Utc);
			actionSheetDatePicker.DatePicker.Date = nsDate;
			actionSheetDatePicker.DatePicker.Mode = mode;
			actionSheetDatePicker.DatePicker.ValueChanged += valueChangedHandler;
			actionSheetDatePicker.Show ();
		}

		private void SubmitForm ()
		{
			try {
				Client client = AuthenticationHelper.GetClient ();
				client.AvailabilityService.UpdateAvailabilityBlock (availabilityBlock);
				hasErrors = false;
			} catch (CntResponseException ex) {
				hasErrors = true;
				Utility.ShowError (ex);
			}
		}

		private void WireUpView ()
		{
			actionButton.TouchUpInside += ActionButtonClicked;
			deleteButton.TouchUpInside += DeleteButtonClicked;

			startButton.TouchUpInside += StartButtonClicked;
			endButton.TouchUpInside += EndButtonClicked;

			//startTimeButton.TouchUpInside += StartTimeClicked; // Doesn't work because of timezone issues.
			startTimeUpButton.TouchUpInside += StartTimeUpClicked;
			startTimeDownButton.TouchUpInside += StartTimeDownClicked;
			//endTimeButton.TouchUpInside += EndTimeClicked; // Doesn't work because of timezone issues.
			endTimeUpButton.TouchUpInside += EndTimeUpClicked;
			endTimeDownButton.TouchUpInside += EndTimeDownClicked;

			sundayButton.TouchUpInside += (object sender, EventArgs e) => WeekDayClicked ("Sunday", (UIButton)sender);
			mondayButton.TouchUpInside += (object sender, EventArgs e) => WeekDayClicked ("Monday", (UIButton)sender);
			tuesdayButton.TouchUpInside += (object sender, EventArgs e) => WeekDayClicked ("Tuesday", (UIButton)sender);
			wednesdayButton.TouchUpInside += (object sender, EventArgs e) => WeekDayClicked ("Wednesday", (UIButton)sender);
			thursdayButton.TouchUpInside += (object sender, EventArgs e) => WeekDayClicked ("Thursday", (UIButton)sender);
			fridayButton.TouchUpInside += (object sender, EventArgs e) => WeekDayClicked ("Friday", (UIButton)sender);
			saturdayButton.TouchUpInside += (object sender, EventArgs e) => WeekDayClicked ("Saturday", (UIButton)sender);
		}
		#endregion
	}
}
