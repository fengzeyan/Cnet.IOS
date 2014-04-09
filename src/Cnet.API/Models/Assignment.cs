using Cnt.Web.API.Models;
using System;

namespace Cnt.API.Models
{
	/// <summary>Represents an assignment.</summary>
	public class Assignment
	{
		/// <summary>Gets or sets the start date and time of the assignment.</summary>
		public DateTime Start { get; set; }

		/// <summary>Gets or sets the duration of the assignment, in number of seconds. A zero value indicates the assignment will take up the rest of the day.</summary>
		public int Duration { get; set; }

		/// <summary>Gets or sets a value indicating if the assignment is canceled.</summary>
		public bool IsCanceled { get; set; }

		/// <summary>Gets or sets the placement the assignment is associated with.</summary>
		public Placement Placement { get; set; }

		internal int ScheduleId { get; set; }

		internal int ScheduleParentId { get; set; }
	}
}
