// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TimesSquare.iOS;
using Cnt.API;
using Cnt.API.Models;
using Cnt.Web.API.Models;
using Cnt.API.Exceptions;

namespace Cnet.iOS
{
	public partial class OSCalendarViewController : UIViewController
	{
		#region Private Methods

		private static NSString assignmentDetailSegueName = new NSString ("AssignmentDetail");
		private static NSString editAvailabilityBlockSegueName = new NSString ("EditAvailabilityBlock");
		private static NSString addAvailabilityBlockSegueName = new NSString ("AddAvailabilityBlock");
		private DateTime selectedDate;
		private List<Assignment> assignments;
		private UserAvailabilityDay userAvailabilityDay;

		#endregion

		public OSCalendarViewController (IntPtr handle) : base (handle)
		{
			assignments = new List<Assignment> ();
		}

		#region Public Methods

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			LoadCalendar ();
			LoadEvents ();
			RenderEvents ();
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			if (segue.Identifier == assignmentDetailSegueName) {
				var indexPath = calendarTable.IndexPathForSelectedRow;
				var selectedAssignment = assignments [indexPath.Row - 1];
				var view = (OSUnconfirmedAssignmentViewController)segue.DestinationViewController;
				view.PlacementId = selectedAssignment.Placement.Id;
			} else if (segue.Identifier == editAvailabilityBlockSegueName) {
				var view = (OSEditAvailabilityViewController)segue.DestinationViewController;
				view.AvailabilityBlockId = userAvailabilityDay.AvailabilityBlockId;
			} else if (segue.Identifier == addAvailabilityBlockSegueName) {
				var view = (AddAvailabilityViewController)segue.DestinationViewController;
				if (userAvailabilityDay != null && userAvailabilityDay.Availability.Count () > 0) {
					TimeBlock time = userAvailabilityDay.Availability.First ();
					view.Start = selectedDate.Date.AddSeconds (time.Start);
					view.End = selectedDate.Date.AddSeconds (time.Start + time.Duration);
				} else
					view.Start = view.End = DateTime.Today;
			}
		}

		#endregion

		#region Event Delegates

		private void ViewEvents (object sender, TSQCalendarViewDelegateAEventArgs e)
		{
			selectedDate = (DateTime)e.Date;
			LoadEvents ();
			RenderEvents ();
		}

		#endregion

		#region Private Methods

		private void LoadCalendar ()
		{
			// Populate list for calendar
			selectedDate = DateTime.Today;
			calendarTable.Source = new OSCalendarTableSource (this);

			// Load calendar view
			var calendarView = new TSQCalendarView (new RectangleF (0, 57, 320, 285)) { // x, y, width, height
				Calendar = new NSCalendar (NSCalendarType.Gregorian),
				FirstDate = NSDate.Now,
				LastDate = NSDate.FromTimeIntervalSinceNow (60 * 60 * 24 * 365 * 5),
				BackgroundColor = UIColor.LightTextColor,
				PagingEnabled = true
			};

			calendarView.DidSelectDate += ViewEvents;

			View.Add (calendarView);
		}

		private void LoadEvents ()
		{
			try {
				Client client = AuthenticationHelper.GetClient ();
				userAvailabilityDay = client.AvailabilityService.GetAvailability (selectedDate, selectedDate).FirstOrDefault ();
				assignments = new List<Assignment> (client.PlacementService.GetAssignments (selectedDate, selectedDate));
			} catch (CntResponseException ex) {
				Utility.ShowError (ex);
			}
		}

		private void RenderEvents ()
		{
			calendarTable.ReloadData ();
		}

		#endregion

		private class OSCalendarTableSource : UITableViewSource
		{
			#region Private Members

			private OSCalendarViewController controller;
			private static NSString CalendarInfoCellId = new NSString ("CalendarInfoCellIdentifier");
			private static NSString CalendarAppointmentCellId = new NSString ("AppointmentCellIdentifier");
			private static NSString CalendarNoAppoinetmentCellId = new NSString ("NoAppointmentCellIdentifier");

			#endregion

			#region Constructors

			public OSCalendarTableSource (OSCalendarViewController parent) : base ()
			{
				controller = parent;
			}

			#endregion

			#region Public Methods

			public override int RowsInSection (UITableView tableview, int section)
			{
				if (controller.assignments == null || controller.assignments.Count == 0)
					return 2; // Info cell and an empty appointment cell.
				return controller.assignments.Count + 1;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = new UITableViewCell ();
				switch (indexPath.Row) {
				case 0:
					cell = tableView.DequeueReusableCell (CalendarInfoCellId, indexPath);
					RenderInfoCell ((OSCalendarInfoCell)cell);
					break;
				default:
					if (controller.assignments.Count >= indexPath.Row) {
						Assignment assignment = controller.assignments [indexPath.Row - 1];
						cell = tableView.DequeueReusableCell (CalendarAppointmentCellId, indexPath);
						RenderAppointmentCell ((OSCalendarAppointmentCell)cell, assignment);
					} else
						cell = tableView.DequeueReusableCell (CalendarNoAppoinetmentCellId, indexPath);
					break;
				}
				return cell;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				switch (indexPath.Row) {
				case 0:
					if (controller.userAvailabilityDay != null && controller.userAvailabilityDay.AvailabilityBlockId > 0)
						controller.PerformSegue (OSCalendarViewController.editAvailabilityBlockSegueName, this);
					else
						controller.PerformSegue (OSCalendarViewController.addAvailabilityBlockSegueName, this);
					break;
				default:
					if (controller.assignments.Count >= indexPath.Row)
						controller.PerformSegue (OSCalendarViewController.assignmentDetailSegueName, this);
					break;
				}
			}

			#endregion

			#region Private Methods

			private void RenderAppointmentCell (OSCalendarAppointmentCell cell, Assignment assignment)
			{
				DateTime start = assignment.Start;
				DateTime end = start.AddSeconds (assignment.Duration);
				cell.StartTimeLabel.Text = start.ToString ("h:mm");
				cell.StartTimePmLabel.Text = start.ToString ("tt").ToUpper ();
				cell.EndTimeLabel.Text = end.ToString ("h:mm");
				cell.EndTimePmLabel.Text = end.ToString ("tt").ToUpper ();
				cell.FamilyNameLabel.Text = assignment.Placement.ToFamilyNameString ();
				cell.StatusLabel.Text = assignment.ToStatusString ();
				if (String.IsNullOrWhiteSpace (assignment.Placement.ClientPhoto))
					cell.ProfileImage.Hidden = cell.ProfileBorderImage.Hidden = true;
				else
					cell.ProfileImage.Image = assignment.Placement.GetProfileImage ();
				cell.FlagImage.Image = assignment.GetStatusFlagImage ();
				cell.StatusImage.Image = assignment.GetStatusImage ();
			}

			private void RenderInfoCell (OSCalendarInfoCell cell)
			{
				cell.DateLabel.Text = controller.selectedDate.ToString ("dddd, MMM. d").ToUpper ();
				if (controller.userAvailabilityDay == null) {
					cell.TimeLabel.Hidden = true;
				} else {
					List<string> timeStrings = new List<string> ();
					foreach (TimeBlock block in controller.userAvailabilityDay.Availability.OrderBy(a => a.Start)) {
						timeStrings.Add ("Available from " + block.ToTimesString ());
					}
					cell.TimeLabel.Lines = timeStrings.Count;
					float expectedHeight = 21 * timeStrings.Count;
					if (cell.TimeLabel.Frame.Height != expectedHeight)
						cell.TimeLabel.AdjustFrame (0, 0, 0, expectedHeight - cell.TimeLabel.Frame.Height);
					cell.TimeLabel.Text = String.Join ("\n", timeStrings);
				}
			}

			#endregion
		}
	}
}
