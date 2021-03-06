// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cnt.API;
using Cnt.API.Exceptions;
using Cnt.API.Models;
using Cnt.Web.API.Models;
using System.Drawing;

namespace Cnet.iOS
{
	public partial class OSAssignmentViewController : UIViewController
	{
		#region Private Members
		private const string AssignmentDetailSegueName = "AssignmentDetail";
		private const string NextAssignmentDetailSegueName = "NextAssignmentDetail";
		private Assignment nextAssignment;
		private List<Assignment> completedAssignments;
		private List<Assignment> upcomingAssignments;
		#endregion

		#region Public Properties
		public List<Assignment> Assignments {
			get { return (Mode == AssignmentType.Completed) ? completedAssignments : upcomingAssignments; }
		}
		public AssignmentType Mode { get; set; }
		#endregion

		public OSAssignmentViewController (IntPtr handle) : base (handle)
		{
			completedAssignments = new List<Assignment> ();
			upcomingAssignments = new List<Assignment> ();
		}

		#region Public Methods
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			LoadAssignments ();
			WireUpView ();
			RenderNextAssignment ();
			RenderAssignments ();
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			if (segue.Identifier == AssignmentDetailSegueName) {
				var indexPath = assignmentsTable.IndexPathForSelectedRow;
				var selectedAssignment = Assignments [indexPath.Row];
				var view = (OSUnconfirmedAssignmentViewController)segue.DestinationViewController;
				view.PlacementId = selectedAssignment.Placement.Id;
			}
			else if (segue.Identifier == NextAssignmentDetailSegueName) {
				var view = (OSUnconfirmedAssignmentViewController)segue.DestinationViewController;
				view.PlacementId = nextAssignment.Placement.Id;
			}
		}
		#endregion

		#region Event Delegates
		private void CallNextAssignment(object sender, EventArgs e)
		{
			if (!Utility.OpenPhoneDailer (nextAssignment.Placement.ClientMobilePhone))
				Utility.OpenPhoneDailer (nextAssignment.Placement.ClientHomePhone);
		}

		partial void completedSwitchPressed (UIButton sender)
		{
			completedButton.Selected = true;
			upcomingButton.Selected = false;
			Mode = AssignmentType.Completed;
			assignmentsTable.ReloadData();
			assignmentsTable.Hidden = (completedAssignments.Count == 0);
		}

		partial void upcomingSwitchPressed (UIButton sender)
		{
			upcomingButton.Selected = true;
			completedButton.Selected = false;
			Mode = AssignmentType.Upcoming;
			assignmentsTable.ReloadData();
			assignmentsTable.Hidden = (upcomingAssignments.Count == 0);
         		}

		private void MessagesClicked (object sender, EventArgs e)
		{
			NotificationHelper.ShowNotificationView (this);
		}

		private void ViewNextAssignmentMap(object sender, EventArgs e)
		{
			Utility.OpenMap (nextAssignment.Placement.Location);
		}
		#endregion

		#region Private Methods
		private void LoadAssignments()
		{
			try {
				Client client = AuthenticationHelper.GetClient ();
				DateRange currentPayPeriod = AuthenticationHelper.UserData.PayPeriod;
				completedAssignments = new List<Assignment> (client.PlacementService.GetCompletedAssignments (currentPayPeriod.Start.Value));
				upcomingAssignments = new List<Assignment> (client.PlacementService.GetUpcomingAssignments (DateTime.Today.AddDays (7)));

				// Next Assignment
				if (upcomingAssignments.Count > 0)
					nextAssignment = upcomingAssignments.Where(a => a.Status == AssignmentStatus.Confirmed && a.Start > DateTime.Now).OrderBy (a => a.Start).First ();
			} catch (CntResponseException ex) {
				Utility.ShowError (ex);
			}
		}

		private void RenderAssignments()
		{
			Mode = AssignmentType.Upcoming;
			assignmentsTable.Source = new OSAssignmentTableSource (this);
			assignmentsTable.Hidden = (upcomingAssignments.Count == 0);

			noAssignmentsImage.Hidden = (upcomingAssignments.Count > 0 || completedAssignments.Count > 0);
		}

		private void RenderNextAssignment()
		{
			if (nextAssignment != null) {
				DateTime end = nextAssignment.Start.AddSeconds (nextAssignment.Duration);

				nextAssignmentDateLabel.Text = nextAssignment.Start.ToString ("dddd MMM d");
				nextAssignmentStartLabel.Text = nextAssignment.Start.ToString ("h:mm");
				nextAssignmentStartPmLabel.Text = nextAssignment.Start.ToString ("tt").ToUpper ();
				nextAssignmentEndLabel.Text = end.ToString ("- h:mm");
				nextAssignmentEndPmLabel.Text = end.ToString ("tt").ToUpper ();
				nextAssignmentFamilyLabel.Text = nextAssignment.Placement.ToFamilyNameString ();

				nextAssignmentMapButton.TouchUpInside += ViewNextAssignmentMap;
				nextAssignmentCallButton.TouchUpInside += CallNextAssignment;
			} else {
				nextAssignmentView.Hidden = true;
				upcomingButton.AdjustFrame (0, -150, 0, 0);
				completedButton.AdjustFrame (0, -150, 0, 0);
				assignmentsTable.AdjustFrame (0, -150, 0, 150);
			}
		}

		private void WireUpView()
		{
			messagesButton.TouchUpInside += MessagesClicked;
			messagesLabel.Text = NotificationHelper.Notifications.Count.ToString ();
		}
		#endregion

		private class OSAssignmentTableSource : UITableViewSource
		{
			#region Private Members
			private OSAssignmentViewController controller;
			private static NSString OSAssignmentsTableViewCellId = new NSString ("AssignmentsCellIdentifier");
			private int purpleLabelMaxWidth = 70;
			#endregion

			public OSAssignmentTableSource(OSAssignmentViewController parent) : base()
			{
				controller = parent;
			}

			#region Public Methods
			public override int RowsInSection (UITableView tableview, int section)
			{
				return controller.Assignments.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				OSAssignmentsTableViewCell cell = (OSAssignmentsTableViewCell)tableView.DequeueReusableCell (OSAssignmentsTableViewCellId, indexPath);

				Assignment assignment = controller.Assignments [indexPath.Row];

				int childCount = assignment.Placement.Students.Count ();

				switch (assignment.Status) {
				case AssignmentStatus.New:
					cell.BelowProfilePicLabel.Text = "Unconfirmed";
					cell.BelowProfilePicLabel.TextColor = Utility.NewTextColor;
					cell.BelowProfilePicLabel.AdjustsFontSizeToFitWidth = true;
					break;
				case AssignmentStatus.Canceled:
					cell.BelowProfilePicLabel.Text = "Cancelled";
					cell.BelowProfilePicLabel.TextColor = UIColor.Black;
					break;
				case AssignmentStatus.Confirmed:
					cell.BelowProfilePicLabel.Text = "Upcoming";
					cell.BelowProfilePicLabel.TextColor = UIColor.Black;
					break;
				default:
					cell.BelowProfilePicLabel.Text = String.Empty;
					break;
				}

				if (childCount > 0)
					cell.ChildrenLabel.Text = (childCount == 1) ? "1 child" : childCount + " children";
				cell.DateLabel.Text = assignment.ToStartString();

				cell.ProfileImage.Image = assignment.Placement.GetProfileImage();
				cell.InfoImage.Image = assignment.Status.GetInfoImage();

				cell.FamilyNameLabel.Text = assignment.Placement.ToFamilyNameString() + " - " + controller.Assignments[indexPath.Row].Placement.SubServiceAbbreviation;

				cell.LocationLabel.Text = assignment.Placement.Location.ToLocationString("{2}, {3}");

				if (assignment.Status == AssignmentStatus.New) {
					cell.BookmarkImage.Image = new UIImage ("icon-bookmark.png");
					cell.PurpleInfoLabel.Text = assignment.Placement.Created.ToTimeSinceString();
				} else {
					cell.BookmarkImage.Hidden = true;
					if (purpleLabelMaxWidth != cell.PurpleInfoLabel.Frame.Width)
						cell.PurpleInfoLabel.AdjustFrame (0, 0, purpleLabelMaxWidth - cell.PurpleInfoLabel.Frame.Width, 0);
					cell.PurpleInfoLabel.Text = (assignment.Status == AssignmentStatus.TimesheetRequired) ? "Timesheet due" : String.Empty;
				}

				cell.TimeLabel.Text = assignment.ToTimesString ();
				return cell;
			}
			#endregion
		}

		public enum AssignmentType
		{
			Completed,
			Upcoming
		}
	}
}