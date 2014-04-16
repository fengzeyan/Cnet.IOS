using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cnt.API.Models;
using Cnt.Web.API.Models;

namespace Cnet.iOS
{
	public static class Utility
	{
		#region Static Settings
		public static UIColor CanceledBackgroundColor = UIColor.FromRGB (255, 0, 87);
		public static UIColor CanceledTextColor = UIColor.FromRGB (134, 15, 56);
		public static UIColor CanceledStatusTextColor = UIColor.FromRGB (255, 0, 67);
		public static UIColor NewTextColor = UIColor.FromRGB (106, 65, 131);
		public static UIColor TimesheetDueTextColor = UIColor.FromRGB (146, 203, 99);
		public static UIColor UpdatedBackgroundColor = UIColor.FromRGB (254, 221, 3);
		public static UIColor UpdatedTextColor = UIColor.FromRGB (160, 116, 85);
		public static UIColor UpdatedStatusTextColor = UIColor.FromRGB (204, 175, 0);
		#endregion

		#region Helper Methods
		public static UIImage UIImageFromUrl(string uri)
		{
			if (String.IsNullOrEmpty (uri))
				return new UIImage ();

			using (var url = new NSUrl (uri))
			using (var data = NSData.FromUrl (url))
				return UIImage.LoadFromData (data);
		}

		public static bool OpenPhoneDailer(string phoneNumber)
		{
			var cleanNumber = new String (phoneNumber.Where (Char.IsDigit).ToArray ());
			return OpenUrl("tel:" + cleanNumber);
		}

		public static bool OpenMap(Address address)
		{
			string mapUrl = String.Format ("http://maps.google.com/maps?f=d&daddr={0} {1} {2} {3} {4}", address.Line1, address.Line2, address.City, address.State, address.Zip).Replace(' ', '+');
			return OpenUrl (mapUrl);
		}

		public static bool OpenUrl(string url)
		{
			var urlToSend = new NSUrl (url);
			if (UIApplication.SharedApplication.CanOpenUrl (urlToSend)) {
				UIApplication.SharedApplication.OpenUrl (urlToSend);
				return true;
			}
			return false;
		}
		#endregion

		#region Extension Methods
		public static void AdjustFrame(this UIView view, float x, float y, float width, float height)
		{
			var frame = view.Frame;
			frame.X += x;
			frame.Y += y;
			frame.Width += width;
			frame.Height += height;
			view.Frame = frame;
		}

		public static AssignmentStatus GetStatus (this List<Assignment> assignments)
		{
			// Default to the lowest priority status.
			AssignmentStatus status = AssignmentStatus.NoTimesheetRequired;
			foreach (Assignment assignment in assignments) {
				AssignmentStatus currentStatus = assignment.GetStatus ();
				if ((int)currentStatus < (int)status)
					status = currentStatus;
			}
			return status;
		}

		public static AssignmentStatus GetStatus (this Assignment assignment)
		{
			AssignmentStatus status;
			if (assignment.Start.AddSeconds (assignment.Duration) >= DateTime.Now) {
				if (assignment.IsCanceled)
					status = AssignmentStatus.Canceled;
				else if (assignment.Placement.SubServiceCategory == 1 && !assignment.Placement.IsConfirmed)
					status = AssignmentStatus.New;
				else
					status = AssignmentStatus.Confirmed;
			} else {
				if (assignment.Placement.HasTimesheets)
					status = AssignmentStatus.NoTimesheetRequired;
				else 
					status = AssignmentStatus.TimesheetRequired;
			}
			return status;
		}

		public static string ToStartString(this Assignment assignment)
		{
			return assignment.Start.ToString("ddd d MMM");
		}

		public static string ToTimesString(this Assignment assignment)
		{
			DateTime end = assignment.Start.AddSeconds (assignment.Duration);
			return assignment.Start.ToString ("h:mmtt").ToLower() + " - " + end.ToString ("h:mmtt").ToLower();
		}

		public static UIImage GetInfoImage(this AssignmentStatus assignmentStatus)
		{
			switch (assignmentStatus) {
			case AssignmentStatus.New:
				return new UIImage("check-off.png");
			case AssignmentStatus.Canceled:
				return new UIImage("icon-cancelled.png");
			case AssignmentStatus.Confirmed:
				return new UIImage("icon-check.png");
			case AssignmentStatus.TimesheetRequired:
				return new UIImage("check-dollar.png");
			default:
				return new UIImage ();
			}
		}

		public static UIImage GetProfileImage(this Placement placement)
		{
			if (String.IsNullOrWhiteSpace (placement.ClientPhoto))
				return new UIImage ("icon-no-image.png");

			return UIImageFromUrl (placement.ClientPhoto);
		}

		public static string ToFamilyNameString(this Placement placement)
		{
			string clientName = placement.ClientName;
			return clientName.Substring (clientName.LastIndexOf (" ") + 1) + " Family";
		}

		public static string ToLocationString(this Placement placement, string format)
		{
			if (placement.Location == null)
				return String.Empty;

			Address location = placement.Location;
			return String.Format(format, location.Line1, location.Line2, location.City, location.State, location.Zip);
		}

		public static string ToAgeString(this Student child)
		{
			if (!child.DateOfBirth.HasValue)
				return String.Empty;

			DateTime dateOfBirth = child.DateOfBirth.Value;
			DateTime currentDate = DateTime.Now;

			int ageInYears = 0;
			int ageInMonths = 0;
			int ageInDays = 0;

			ageInDays = currentDate.Day - dateOfBirth.Day;
			ageInMonths = currentDate.Month - dateOfBirth.Month;
			ageInYears = currentDate.Year - dateOfBirth.Year;

			if (ageInDays < 0)
			{
				ageInDays += DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
				ageInMonths = ageInMonths--;

				if (ageInMonths < 0)
				{
					ageInMonths += 12;
					ageInYears--;
				}
			}
			if (ageInMonths < 0)
			{
				ageInMonths += 12;
				ageInYears--;
			}

			return String.Format("{0}yo {1}mo", ageInYears, ageInMonths);
		}
		#endregion
	}

	public enum AssignmentStatus
	{
		New,
		TimesheetRequired,
		Canceled,
		Updated,
		Confirmed,
		NoTimesheetRequired
  	}
}

