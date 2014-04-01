using System;
using System.ComponentModel;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents the user notification types.</summary>
    [Flags]
    public enum ApiUserNotifications
    {
        /// <summary>No notifications.</summary>
        None = 0,

        /// <summary>The user will receive a notification when placements they are associated with are confirmed.</summary>
        [Description("Placement Confirmed")]
        PlacementCreated = 1,

        /// <summary>The user will receive a notification when placements they are associated with are updated.</summary>
        [Description("Placement Updated")]
        PlacementUpdated = 2,

        /// <summary>The user will receive a notification when placements they are associated with are canceled.</summary>
        [Description("Placement Canceled")]
        PlacementCanceled = 4,

        /// <summary>The user will receive a notification when placements they are associated with are about to start.</summary>
        [Description("Placement Reminder")]
        PlacementReminders = 8,

        /// <summary>The user will receive a notification when they need to enter timesheets for a placement.</summary>
        [Description("Placement Submit Timesheet")]
        PlacementSubmitTimesheet = 16,

        /// <summary>The user will receive a notification when they need to update their availability.</summary>
        [Description("Update Availability")]
        UpdateAvailability = 32,

        /// <summary>The user will receive a notification when the need to ensure their profile data is up-to-date.</summary>
        [Description("Update Profile")]
        UpdateProfile = 64
    }
}