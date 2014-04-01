using System;
using System.Collections.Generic;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents an availability block for a user.</summary>
    public class AvailabilityBlock
    {
        /// <summary>Gets or sets the ID of the availability block.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the ID of the availability block's parent.</summary>
        public int? ParentId { get; set; }

        /// <summary>Gets or sets the ID of the user the availability block is associated with.</summary>
        public int UserId { get; set; }

        /// <summary>Gets or sets the ID of the availability block's parent.</summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end date of the availability block. If null/empty, the system will assume a block size of one year (to be consistent with existing
        /// functionality in the resource center). Use the same date as the start date for single day blocks.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>Gets or sets a comma delimited list of the days of the week. Null/empty values will be treated as all of the days of the week.</summary>
        public string Weekdays { get; set; }

        /// <summary>
        /// Gets or sets the times for the availability block. If there are multiple time blocks, if any overlap then the overlapping blocks will be combined into a
        /// single time block. If the duration of a time block would cause it to go into the next day, then it is cut off at midnight. If the start time is greater
        /// than the number of seconds in a day, an exception will be thrown.
        /// </summary>
        public IEnumerable<TimeBlock> Times { get; set; }
    }
}