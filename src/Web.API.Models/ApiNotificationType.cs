using System;
using System.ComponentModel;

namespace Cnet.Data
{
    /// <summary>Represents the notification type.</summary>
    public enum ApiNotificationType
    {
        /// <summary>No notification type specified.</summary>
        None = 0,

        /// <summary>A notification that is sent out when a placement the user is associated with has been created.</summary>
        [Description("Placement Created")]
        PlacementCreated = 1,

        /// <summary>A notification that is sent out when a placement the user is associated with has been changed.</summary>
        [Description("Placement Updated")]
        PlacementUpdated = 2,

        /// <summary>A notification that is sent out when a placement the user is associated with has been canceled.</summary>
        [Description("Placement Canceled")]
        PlacementCanceled = 3,

        /// <summary>A notification that is sent out when a placement the user is associated with is about to begin.</summary>
        [Description("Placement Reminder")]
        PlacementReminder = 4,

        /// <summary>A notification that is sent out reminding the user that they need to enter their time for a placement.</summary>
        [Description("Placement Submit Timesheet")]
        PlacementSubmitTimesheet = 5,

        /// <summary>A notification that is sent out reminding the user to ensure their availability is up-to-date.</summary>
        [Description("Update Availability")]
        UpdateAvailability = 6,

        /// <summary>A notification that is sent out reminding the user to ensure their profile data is up-to-date.</summary>
        [Description("Update Profile")]
        UpdateProfile = 7
    }
}