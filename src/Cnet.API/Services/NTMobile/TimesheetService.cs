using Cnt.Web.API.Models;
using System.Collections.Generic;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing timesheets for the current user.
	/// </summary>
	public class TimesheetService
	{		
		Client _Client;
		internal TimesheetService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets all timesheets for the current user.
		/// </summary>
		/// <returns>All timesheets for the current user.</returns>
		public IEnumerable<Timesheet> GetTimesheets()
		{
			return CntRestHelper.Request<IEnumerable<Timesheet>>(Constants.NTMOBILE_BASEURL + "/timesheets", _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Gets a timesheet.
		/// </summary>
		/// <param name="timesheetId">The timesheet identifier.</param>
		/// <returns>The timesheet.</returns>
		public Timesheet GetTimesheet(int timesheetId)
		{
			return CntRestHelper.Request<Timesheet>(Constants.NTMOBILE_BASEURL + "/timesheet/" + timesheetId, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Adds a timesheet.
		/// </summary>
		/// <param name="timesheet">The timesheet.</param>
		/// <returns>The identifier of the added timesheet.</returns>
		public int AddTimesheet(Timesheet timesheet)
		{
			var newTimesheet = CntRestHelper.JSONRequest<Timesheet>(Constants.NTMOBILE_BASEURL + "/timesheet/", _Client.UserName, _Client.Password, timesheet, CntRestHelper.RequestMethod.POST).Data;
			timesheet.Id = newTimesheet.Id;
			return timesheet.Id;
		}

		/// <summary>
		/// Updates a timesheet.
		/// </summary>
		/// <param name="timesheet">The timesheet.</param>
		/// <returns><c>true</c> if the timesheet was updated, <c>false</c> otherwise.</returns>
		public void UpdateTimesheet(Timesheet timesheet)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/timesheet/" + timesheet.Id, _Client.UserName, _Client.Password, timesheet, CntRestHelper.RequestMethod.PUT);
		}

		/// <summary>
		/// Deletes a timesheet.
		/// </summary>
		/// <param name="timesheetId">The timesheet identifier.</param>
		/// <returns><c>true</c> if the notification was deleted, <c>false</c> otherwise.</returns>
		public void DeleteTimesheet(int timesheetId)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/timesheet/" + timesheetId, _Client.UserName, _Client.Password, null, CntRestHelper.RequestMethod.DELETE);
		}
	}
}
