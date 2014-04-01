using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents the data returned by the profile status method for the NT mobile application.</summary>
    public class NTMobileAppProfileStatus
    {
        /// <summary>Gets or sets the new placement count of the current user.</summary>
        public int NewPlacementCount { get; set; }

        /// <summary>Gets or sets the count of the placements for the current user that don't have timesheets entered.</summary>
        public int PlacementsWithoutTimesheetsCount { get; set; }

        /// <summary>Gets or sets the next placement start date.</summary>
        public DateTime? NextPlacementStart { get; set; }

        /// <summary>Gets or sets the ID of the next placement.</summary>
        public int? NextPlacementId { get; set; }
    }
}