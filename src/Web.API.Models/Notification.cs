using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a device notification.</summary>
    public class Notification
    {
        /// <summary>Gets or sets the ID of the notification.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the ID of the user the notification is associated with.</summary>
        public int UserId { get; set; }

        /// <summary>Gets or sets the date the notification was created.</summary>
        public DateTime Created { get; set; }

        /// <summary>Gets or sets the type of the notification. Possible values: "PlacementCreated", "PlacementUpdated", "PlacementCanceled", "PlacementReminders", "PlacementSubmitTimesheet", "UpdateAvailability", and "UpdateProfile".</summary>
        public string Type { get; set; }

        /// <summary>Gets or sets the title of the notification.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the text of the notification.</summary>
        public string Text { get; set; }

        /// <summary>Gets or sets a value indicating if the notification has been acknowledged by the user.</summary>
        public bool Acknowledged { get; set; }

        ///// <summary>Gets or sets the date the notification was acknowledged.</summary>
        //public DateTime? DateAcknowledged { get; set; }

        /// <summary>Gets or sets the ID of the object associated with the notification, if there is one. Can be <c>null</c>.</summary>
        public int? AssociatedId { get; set; }
    }
}