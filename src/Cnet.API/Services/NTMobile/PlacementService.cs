using Cnt.API.Models;
using Cnt.API.Utils;
using Cnt.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing placements for the current user.
	/// </summary>
	public class PlacementService
	{
		Client _Client;
		internal PlacementService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets all upcoming assignments for the current user from now to the specified date.
		/// </summary>
		/// <param name="toDate">The to date.</param>
		/// <returns>All upcoming assignments for the current user from now to the specified date.</returns>
		public IEnumerable<Assignment> GetUpcomingAssignments(DateTime toDate)
		{
			return GetAssignmentsInternal(DateTime.Now, toDate);
		}

		/// <summary>
		/// Gets all upcoming assignments for the current user for the specified dates.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>All upcoming assignments for the current user for the specified dates.</returns>
		[Obsolete("Use GetUpcomingAssignments(DateTime toDate) instead.")]
		public IEnumerable<Assignment> GetUpcomingAssignments(DateTime startDate, DateTime endDate)
		{
			// Upcoming assignments are in the future.
			if (startDate < DateTime.Now)
				startDate = DateTime.Now;
			return GetAssignmentsInternal(startDate, endDate);
		}

		/// <summary>
		/// Gets all completed assignments for the current user from the specified date to now.
		/// </summary>
		/// <param name="fromDate">The from date.</param>
		/// <returns>All completed assignments for the current user from the specified date to now.</returns>
		public IEnumerable<Assignment> GetCompletedAssignments(DateTime fromDate)
		{
			return GetAssignmentsInternal(fromDate, DateTime.Now);
		}

		/// <summary>
		/// Gets all completed assignments for the current user for the specified dates.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>All completed assignments for the current user for the specified dates.</returns>
		[Obsolete("Use GetCompletedAssignments(DateTime fromDate) instead.")]
		public IEnumerable<Assignment> GetCompletedAssignments(DateTime startDate, DateTime endDate)
		{
			// Completed assignments are in the past.
			if (endDate > DateTime.Now)
				endDate = DateTime.Now;
			return GetAssignmentsInternal(startDate, endDate);
		}

		/// <summary>
		/// Gets all completed assignments for the current user for the specified dates.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>All completed assignments for the current user for the specified dates.</returns>
		public IEnumerable<Assignment> GetAssignments(DateTime startDate, DateTime endDate)
		{
			return GetAssignmentsInternal(startDate, endDate);
		}

		/// <summary>
		/// Gets the all assignments for the given placement and dates.
		/// </summary>
		/// <param name="placement">The placement.</param>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>All assignments for the given placement and dates.</returns>
		public IEnumerable<Assignment> GetAssignments(Placement placement, DateTime startDate, DateTime endDate)
		{
			var timesheets = _Client.TimesheetService.GetTimesheets(startDate, endDate);
			//var updateNotifications = _Client.NotificationService.GetPlacementUpdatedNotifications();
			return GetAssignmentsInternal(placement, timesheets, null, startDate, endDate);
		}

		/// <summary>
		/// Gets all placements for the current user.
		/// </summary>
		/// <returns>All placements for the current user.</returns>
		public IEnumerable<Placement> GetPlacements()
		{
			return CntRestHelper.Request<IEnumerable<Placement>>(Constants.NTMOBILE_BASEURL + "/placements", _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Gets a filtered list of all placements for the current user.
		/// </summary>
		/// <param name="query">The query used to filter.</param>
		/// <returns>A filtered list of all placements for the current user.</returns>
		public IEnumerable<Placement> GetPlacements(string query)
		{
			return CntRestHelper.Request<IEnumerable<Placement>>(Constants.NTMOBILE_BASEURL + "/placements?q=" + query, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Gets a placement.
		/// </summary>
		/// <param name="placementId">The placement identifier.</param>
		/// <returns>The placement.</returns>
		public Placement GetPlacement(int placementId)
		{
			return CntRestHelper.Request<Placement>(Constants.NTMOBILE_BASEURL + "/placement/" + placementId, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Confirms a placement.
		/// </summary>
		/// <param name="placementId">The placement identifier.</param>
		/// <returns><c>true</c> if the notification was confirmed, <c>false</c> otherwise.</returns>
		public void ConfirmPlacement(int placementId)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/placement/" + placementId + "/confirm", _Client.UserName, _Client.Password, null, CntRestHelper.RequestMethod.PUT);
		}

		/// <summary>
		/// Declines a placement.
		/// </summary>
		/// <param name="placementId">The placement identifier.</param>
		/// <returns><c>true</c> if the notification was declined, <c>false</c> otherwise.</returns>
		public void DeclinePlacement(int placementId)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/placement/" + placementId + "/decline", _Client.UserName, _Client.Password, null, CntRestHelper.RequestMethod.PUT);
		}

		#region Private

		/// <summary>
		/// Gets all assignments from a list of placements for the specified dates.
		/// </summary>
		/// <param name="placements">The placements.</param>
		/// <param name="type">The type of assignments to load.</param>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>All assignments for the specified week.</returns>
		private IList<Assignment> GetAssignmentsInternal(DateTime startDate, DateTime endDate)
		{
			string query = String.Format("Start <= {0} AND End >= {1}", startDate.ToShortDateString(), endDate.ToShortDateString());
			var placements = GetPlacements(query);
			var timesheets = _Client.TimesheetService.GetTimesheets(startDate, endDate);
			//var updateNotifications = _Client.NotificationService.GetPlacementUpdatedNotifications();

			var assignments = new List<Assignment>();
			foreach (Placement placement in placements)
			{
				//assignments.AddRange(GetAssignmentsInternal(placement, timesheets.Where(t => t.PlacementId == placement.Id), updateNotifications.Where(n => n.AssociatedId == placement.Id), startDate, endDate));
				assignments.AddRange(GetAssignmentsInternal(placement, timesheets.Where(t => t.PlacementId == placement.Id), null, startDate, endDate));
			}

			// Order "New" status first, then order by date.
			return assignments.OrderByDescending(a => a.Status == AssignmentStatus.New).ThenBy(a => a.Start).ToList();
		}

		/// <summary>
		/// Gets all assignments from a placement for the specified dates.
		/// </summary>
		/// <param name="placement">The placement.</param>
		/// <param name="type">The type of assignments to load.</param>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>All assignments from the placement for the specified week.</returns>
		private IList<Assignment> GetAssignmentsInternal(Placement placement, IEnumerable<Timesheet> timesheets, IEnumerable<Notification> updateNotifications, DateTime startDate, DateTime endDate)
		{
			List<Assignment> assignments = new List<Assignment>();
			foreach (Schedule schedule in placement.Schedules)
			{
				AdvanceSchedule advSchedule = new AdvanceSchedule(schedule);
				DateTime? nextOccurrence = advSchedule.NextOccurrence(startDate.AddDays(-1));
				while (nextOccurrence.HasValue && nextOccurrence.Value < endDate.AddDays(1))
				{
					// Determine if the assignment is canceled.
					bool isCanceled = placement.IsCanceled || schedule.IsCanceled;
					foreach (DateRange cancelDate in placement.CancelDates)
					{
						isCanceled = isCanceled || (nextOccurrence.Value >= cancelDate.Start && nextOccurrence.Value <= cancelDate.End);
					}

					// Save the start time and get the next occurrence now so we can continue if we need to.
					DateTime start = nextOccurrence.Value.AddSeconds(schedule.Time.Start);
					nextOccurrence = advSchedule.NextOccurrence(nextOccurrence.Value);

					// If a "break off" of the new assignment is already in our assignments list, skip this assignment (it is the parent and the "break off" has priority).
					Assignment child = assignments.FirstOrDefault(a => a.ScheduleParentId == schedule.Id && a.Start.Date == start.Date);
					if (child != null)
					{
						// If the "break off" is canceled, remove it so it can be replaced by the parent.
						if (child.Status == AssignmentStatus.Canceled)
							assignments.Remove(child);
						else
							continue;
					}

					// If we have a "break off" assignment and the parent is already in our assignments list, remove the parent so it can be replaced with the "break off" one.
					Assignment parent = assignments.FirstOrDefault(a => a.ScheduleId == schedule.ParentId && a.Start.Date == start.Date && !isCanceled);
					if (parent != null)
						assignments.Remove(parent);

					bool isCompleted = start.AddSeconds(schedule.Time.Duration) < DateTime.Now;
					bool hasTimesheet = (timesheets != null) && timesheets.Any(t => t.Start.Date == start.Date && DateHelper.DateDiff(DatePart.Second, t.Start, t.End) == schedule.Time.Duration);
					bool hasUpdates = (updateNotifications != null) && (updateNotifications.Count() > 0);
					AssignmentStatus status;
					if (isCompleted)
					{
						if (hasTimesheet)
							status = AssignmentStatus.NoTimesheetRequired;
						else
							status = AssignmentStatus.TimesheetRequired;
					}
					else
					{
						if (isCanceled)
							status = AssignmentStatus.Canceled;
						else if (placement.SubServiceCategory == 1 && !placement.IsConfirmed)
							status = AssignmentStatus.New;
						else if (hasUpdates)
							status = AssignmentStatus.Updated;
						else
							status = AssignmentStatus.Confirmed;
					}

					assignments.Add(new Assignment()
					{
						Start = start,
						Duration = schedule.Time.Duration,
						Status = status,
						Placement = placement,
						ScheduleId = schedule.Id,
						ScheduleParentId = schedule.ParentId
					});
				}
			}
			return assignments;
		}
		#endregion
	}
}
