using System;
using System.Collections.Generic;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a placement.</summary>
    public class Placement
    {
        /// <summary>Gets or sets the ID of the placement.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the ID of the user the placement is associated with.</summary>
        public int UserId { get; set; }

        /// <summary>Gets or sets the date of the first occurrence of the placement.</summary>
        public DateTime Start { get; set; }

        /// <summary>Gets or sets the date of the last occurrence of the placement.</summary>
        public DateTime? End { get; set; }

        /// <summary>Gets or sets a value indicating if the placement is canceled.</summary>
        public bool IsCanceled { get; set; }

        /// <summary>Gets or sets a value indicating if the placement is confirmed. Always true for order types other than on-call.</summary>
        public bool IsConfirmed { get; set; }

        /// <summary>Gets or sets a value indicating if the placement has timesheets entered for it.</summary>
        public bool HasTimesheets { get; set; }

        /// <summary>Gets or sets the date the placement was created.</summary>
        public DateTime Created { get; set; }

        /// <summary>Gets or sets the title of the placement.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the description of the placement.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the notes for the placement.</summary>
        public string Notes { get; set; }

        /// <summary>Gets or sets the status of the placement.</summary>
        public string Status { get; set; }

        /// <summary>Gets or sets the service of the placement ("Nanny" or "Tutor").</summary>
        public string Service { get; set; }

        /// <summary>Gets or sets the sub-service of the placement.</summary>
        public string SubService { get; set; }

        /// <summary>Gets or sets the name of the client associated with the placement.</summary>
        public string ClientName { get; set; }

        /// <summary>Gets or sets the home phone number of the client associated with the placement.</summary>
        public string ClientHomePhone { get; set; }

        /// <summary>Gets or sets the mobile phone number of the client associated with the placement.</summary>
        public string ClientMobilePhone { get; set; }

        /// <summary>Gets or sets the URL to the photo in Amazon S3 storage of the client associated with the placement.</summary>
        public string ClientPhoto { get; set; }

        /// <summary>Gets or sets the location of the placement.</summary>
        public Address Location { get; set; }

        /// <summary>Gets or sets the important details of the client associated with the placement.</summary>
        public string ImportantDetails { get; set; }

        /// <summary>Gets or sets the students/children associated with the placement.</summary>
        public IEnumerable<Student> Students { get; set; }

        /// <summary>Gets or sets the schedules for the placement.</summary>
        public IEnumerable<Schedule> Schedules { get; set; }

        /// <summary>Gets or sets the dates the placement is canceled.</summary>
        public IEnumerable<DateRange> CancelDates { get; set; }
    }
}