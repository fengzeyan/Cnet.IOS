using System;
using System.Collections.Generic;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents the availability for a specified date for a user.</summary>
    public class UserAvailabilityDay
    {
        /// <summary>Gets or sets the ID of the availability block this availability day falls within.</summary>
        public int AvailabilityBlockId { get; set; }

        /// <summary>Gets or sets the date of the availability.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the times the user is available for the specified date.</summary>
        public IEnumerable<TimeBlock> Availability { get; set; }
    }
}