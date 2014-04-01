using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a timesheet entry for a placement.</summary>
    public class Timesheet
    {
        /// <summary>Gets or sets the ID of the timesheet.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the ID of the placement the timesheet is associated with.</summary>
        public int PlacementId { get; set; }

        /// <summary>Gets or sets the description of the timesheet.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the start date of the timesheet.</summary>
        public DateTime Start { get; set; }

        /// <summary>Gets or sets the end date of the timesheet.</summary>
        public DateTime End { get; set; }

        /// <summary>Gets or sets the date the timesheet was created.</summary>
        public DateTime Created { get; set; }
    }
}