using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a user's associated office information.</summary>
    public class UserOfficeInfo
    {
        /// <summary>Gets or sets the ID of the office.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets a value indicating if the office requires a recap when entering timesheets.</summary>
        public bool TimesheetRecap { get; set; }

        /// <summary>Gets or sets the office phone number.</summary>
        public string Phone { get; set; }
    }
}