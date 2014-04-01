using System;
using System.Collections.Generic;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents the availability for a user.</summary>
    public class UserAvailability
    {
        /// <summary>Gets or sets the ID of the user the availability is for.</summary>
        public int UserId { get; set; }

        /// <summary>Gets or sets the availability for the user.</summary>
        public IEnumerable<UserAvailabilityDay> Availability { get; set; }
    }
}