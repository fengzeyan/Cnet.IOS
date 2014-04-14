using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Cnt.Web.API.Models;
using Cnt.API.Models;

namespace Cnet.iOS
{
	public static class Utility
	{
		public static UIColor CanceledBackgroundColor = UIColor.FromRGB (255, 0, 87);
		public static UIColor CanceledTextColor = UIColor.FromRGB (134, 15, 56);
		public static UIColor CanceledStatusTextColor = UIColor.FromRGB (255, 0, 67);
		public static UIColor NewTextColor = UIColor.FromRGB (106, 65, 131);
		public static UIColor TimesheetDueTextColor = UIColor.FromRGB (146, 203, 99);
		public static UIColor UpdatedBackgroundColor = UIColor.FromRGB (254, 221, 3);
		public static UIColor UpdatedTextColor = UIColor.FromRGB (160, 116, 85);
		public static UIColor UpdatedStatusTextColor = UIColor.FromRGB (204, 175, 0);

		public static UIImage UIImageFromUrl(string uri)
		{
			if (String.IsNullOrEmpty (uri))
				return new UIImage ();

			using (var url = new NSUrl (uri))
			using (var data = NSData.FromUrl (url))
				return UIImage.LoadFromData (data);
		}

		public static void AdjustFrame(this UIView view, float x, float y, float width, float height)
		{
			var frame = view.Frame;
			frame.X += x;
			frame.Y += y;
			frame.Width += width;
			frame.Height += height;
			view.Frame = frame;
		}

		public static void SetFrame(this UIView view, float? x, float? y, float? width, float? height)
		{
			var frame = view.Frame;
			frame.X = x.HasValue ? x.Value : frame.X;
			frame.Y = y.HasValue ? y.Value : frame.Y;
			frame.Width = width.HasValue ? width.Value : frame.Width;
			frame.Height = height.HasValue ? height.Value : frame.Height;
			view.Frame = frame;
		}

		#region Assignment Extensions
		public static AssignmentStatus GetStatus (this Assignment assignment)
		{
			AssignmentStatus status = AssignmentStatus.None;
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

		public static UIImage GetInfoImage(this Assignment assignment)
		{
			switch (assignment.GetStatus ()) {
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

		public static UIImage GetProfileImage(this Assignment assignment)
		{
			if (String.IsNullOrWhiteSpace (assignment.Placement.ClientPhoto))
				return new UIImage ("icon-no-image.png");

			return UIImageFromUrl (assignment.Placement.ClientPhoto);
		}

		public static string ToLocationString(this Assignment assignment, string format)
		{
			if (assignment.Placement.Location == null)
				return String.Empty;

			Address location = assignment.Placement.Location;
			return String.Format(format, location.Line1, location.Line2, location.City, location.State, location.Zip);
		}
		#endregion

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
	}

	public enum AssignmentStatus
	{
		None,
		New,
		Confirmed,
		Updated,
		TimesheetRequired,
		NoTimesheetRequired,
		Canceled
	}

	public enum AssignmentType
	{
		Completed,
		Upcoming
	}
}

