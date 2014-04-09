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
		/// Gets all upcoming assignments for the current user for the current week.
		/// </summary>
		/// <returns>All upcoming assignments for the current user for the current week.</returns>
		public IEnumerable<Assignment> GetUpcomingAssignments()
		{
			DateTime startDate = DateTime.Today;
			DateTime endDate = DateTime.Today.AddDays(7);
			return GetAssignments(AssignmentType.Upcoming, startDate, endDate);
		}

		/// <summary>
		/// Gets all completed assignments for the current user for the current week.
		/// </summary>
		/// <returns>All completed assignments for the current user for the current week.</returns>
		public IEnumerable<Assignment> GetCompletedAssignments()
		{
			DateTime startDate = DateTime.Today;
			DateTime endDate = DateTime.Today.AddDays(7);
			return GetAssignments(AssignmentType.Completed, startDate, endDate);
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
		/// Gets a filterd list of all placements for the current user.
		/// </summary>
		/// <param name="query">The query used to filter.</param>
		/// <returns>All placements for the current user.</returns>
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
		/// Gets all assignments from a list of placements for the specified week.
		/// </summary>
		/// <param name="placements">The placements.</param>
		/// <param name="type">The type of assignments to load.</param>
		/// <param name="startDate">The start of week.</param>
		/// <param name="endDate">The end of week.</param>
		/// <returns>All assignments for the specified week</returns>
		private IEnumerable<Assignment> GetAssignments(AssignmentType type, DateTime startDate, DateTime endDate)
		{
			string query = String.Format("Start < {0} AND End > {1}", startDate.ToShortDateString(), endDate.ToShortDateString());
			IEnumerable<Placement> placements = GetPlacements(query);

			List<Assignment> assignments = new List<Assignment>();
			foreach (Placement placement in placements)
			{
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

						// If we are only loading completed assignments and the assignment is not completed, skip it.
						bool isCompleted = start.AddSeconds(schedule.Time.Duration) < DateTime.Now;
						if (type == AssignmentType.Completed && !isCompleted)
							continue;

						// If a "break off" of the new assignment is already in our assignments list, skip this assignment (it is the parent and the "break off" has priority).
						Assignment child = assignments.FirstOrDefault(a => a.ScheduleParentId == schedule.Id && a.Start.Date == start.Date);
						if (child != null)
						{
							// If the "break off" is canceled, remove it so it can be replaced by the parent.
							if (child.IsCanceled)
								assignments.Remove(child);
							else
								continue;
						}

						// If we have a "break off" assignment and the parent is already in our assignments list, remove the parent so it can be replaced with the "break off" one.
						Assignment parent = assignments.FirstOrDefault(a => a.ScheduleId == schedule.ParentId && a.Start.Date == start.Date && !isCanceled);
						if (parent != null)
							assignments.Remove(parent);

						assignments.Add(new Assignment()
						{
							Start = start,
							Duration = schedule.Time.Duration,
							IsCanceled = isCanceled,
							Placement = placement,
							ScheduleId = schedule.Id,
							ScheduleParentId = schedule.ParentId
						});
					}
				}
			}

			// Order "New" (subtype category and unconfirmed) status first, then order by date descending.
			assignments.OrderBy(a => a.Placement.SubServiceCategory == 1 && !a.Placement.IsConfirmed).ThenByDescending(a => a.Start);

			return assignments;
		}

		private enum AssignmentType
		{ 
			Upcoming,
			Completed
		}

		#endregion
	}
}
