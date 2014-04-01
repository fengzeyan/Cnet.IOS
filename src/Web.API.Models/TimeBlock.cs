using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a block of time.</summary>
    public class TimeBlock
    {
        /// <summary>Gets or sets the time of day that the time block starts, in number of seconds since midnight.</summary>
        public int Start { get; set; }

        /// <summary>Gets or sets the duration of the time block, in number of seconds. A zero value indicates the block will take up the rest of the day.</summary>
        public int Duration { get; set; }
    }
}