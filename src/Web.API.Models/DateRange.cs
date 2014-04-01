using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a date range.</summary>
    public class DateRange
    {
        /// <summary>Gets or sets the start date.</summary>
        public DateTime? Start { get; set; }

        /// <summary>Gets or sets the end date.</summary>
        public DateTime? End { get; set; }
    }
}