using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a user.</summary>
    public class User
    {
        /// <summary>Gets or sets the ID of the user.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the first name of the user.</summary>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the middle name of the user.</summary>
        public string MiddleName { get; set; }

        /// <summary>Gets or sets the last name of the user.</summary>
        public string LastName { get; set; }

        /// <summary>Gets or sets the preferred name of the user.</summary>
        public string PreferredName { get; set; }

        /// <summary>Gets or sets the home phone of the user.</summary>
        public string HomePhone { get; set; }

        /// <summary>Gets or sets the ID of the user.</summary>
        public string MobilePhone { get; set; }

        /// <summary>Gets or sets the mobile carrier of the user.</summary>
        public string MobileCarrier { get; set; }

        /// <summary>Gets or sets a value indicating if the user is allowing the system to send them text messages.</summary>
        public bool AllowTexts { get; set; }

        /// <summary>Gets or sets the work phone of the user.</summary>
        public string WorkPhone { get; set; }

        /// <summary>Gets or sets the school phone of the user.</summary>
        public string SchoolPhone { get; set; }

        /// <summary>Gets or sets the other phone of the user.</summary>
        public string OtherPhone { get; set; }

        /// <summary>Gets or sets the email address of the user.</summary>
        public string Email { get; set; }

        /// <summary>Gets or sets the URL to the photo of the user in S3 storage.</summary>
        public string Photo { get; set; }

        /// <summary>Gets or sets the emergency contact name for the user.</summary>
        public string EmergencyContactName { get; set; }

        /// <summary>Gets or sets the emergency contact phone for the user.</summary>
        public string EmergencyContactPhone { get; set; }

        /// <summary>Gets or sets the current address of the user.</summary>
        public Address AddressCurrent { get; set; }

        /// <summary>Gets or sets the alternate 1 address of the user.</summary>
        public Address AddressAlternate1 { get; set; }

        /// <summary>Gets or sets the alternate 2 address of the user.</summary>
        public Address AddressAlternate2 { get; set; }

        /// <summary>Gets or sets the alternate 3 address of the user.</summary>
        public Address AddressAlternate3 { get; set; }

        /// <summary>Gets or sets the alternate 4 address of the user.</summary>
        public Address AddressAlternate4 { get; set; }

        /// <summary>Gets or sets the alternate 5 address of the user.</summary>
        public Address AddressAlternate5 { get; set; }

        /// <summary>Gets or sets a value indicating if the users availability is locked and can not be changed (by the user themselves, CNeT users can still change it).</summary>
        public bool AvailabilityLocked { get; set; }

        /// <summary>Gets or sets a comma delimited list of the notifications the user has enabled. Possible values: "PlacementCreated", "PlacementUpdated", "PlacementCanceled", "PlacementReminders", "PlacementSubmitTimesheet", "UpdateAvailability", and "UpdateProfile".</summary>
        public string Notifications { get; set; }
    }
}