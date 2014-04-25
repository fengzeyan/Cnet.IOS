namespace Cnt.API.Models
{
	/// <summary>Represents all possible statuses of an assignment.</summary>
	public enum AssignmentStatus
	{
		/// <summary>An upcoming unconfirmed assignment with the sub service category of 1.</summary>
		New = 0,

		/// <summary>A completed assignment with no associated timesheet.</summary>
		TimesheetRequired = 1,

		/// <summary>A canceled assignment.</summary>
		Canceled = 2,

		/// <summary>An upcoming confirmed assignment with updates.</summary>
		Updated = 3,

		/// <summary>An upcoming confirmed assignment.</summary>
		Confirmed = 4,

		/// <summary>A completed assignment with an associated timesheet.</summary>
		NoTimesheetRequired = 5
	}
}
