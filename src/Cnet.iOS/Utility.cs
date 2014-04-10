using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Cnt.Web.API.Models;
using Cnt.API.Models;

namespace Cnet.iOS
{
	public static class Utility
	{
		public static UIImage UIImageFromUrl(string uri)
		{
			if (String.IsNullOrEmpty (uri))
				return new UIImage ();

			using (var url = new NSUrl (uri))
			using (var data = NSData.FromUrl (url))
				return UIImage.LoadFromData (data);
		}

		public static AssignmentStatus GetStatus (this Assignment assignment, AssignmentType type)
		{
			AssignmentStatus status;
			if (type == AssignmentType.Upcoming) {
				if (assignment.IsCanceled)
					status = AssignmentStatus.Canceled;
				else if (assignment.Placement.SubServiceCategory == 1 && !assignment.Placement.IsConfirmed)
					status = AssignmentStatus.New;
				else
					status = AssignmentStatus.Confirmed;
			} else
				status = AssignmentStatus.TimesheetRequired;
			return status;
		}
	}

	public enum AssignmentStatus
	{
		None,
		New,
		Confirmed,
		Canceled,
		TimesheetRequired
	}

	public enum AssignmentType
	{
		Completed,
		Upcoming
	}
}

