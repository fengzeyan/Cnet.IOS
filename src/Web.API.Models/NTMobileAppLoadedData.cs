using System;
using System.Collections.Generic;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents the data returned when the application is loaded.</summary>
    public class NTMobileAppLoadData
    {
        /// <summary>Gets or sets the offices the user is associated with.</summary>
        public IEnumerable<UserOfficeInfo> Offices { get; set; }

        /// <summary>Gets or sets ID of the current user.</summary>
        public int UserId { get; set; }

        /// <summary>Gets or sets a value indicating if the current user can not update their availability.</summary>
        public bool AvailabilityLocked { get; set; }

        /// <summary>Gets or sets the start and end dates of the current pay period.</summary>
        public DateRange PayPeriod { get; set; }

        /// <summary>Gets or sets a comma delimited list of the notifications the user has enabled. Possible values: "PlacementCreated", "PlacementUpdated", "PlacementCanceled", "PlacementReminders", "PlacementSubmitTimesheet", "UpdateAvailability", and "UpdateProfile".</summary>
        public string Notifications { get; set; }
    }
}