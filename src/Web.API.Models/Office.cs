using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents an office.</summary>
    public class Office
    {
        /// <summary>Gets or sets the ID of the office.</summary>
		public int Id { get; set; }

		/// <summary>Gets or sets the name of the office.</summary>
		public string Name { get; set; }

        /// <summary>Gets or sets a value indicating if the office requires a recap when entering timesheets.</summary>
        public bool TimesheetRecap { get; set; }

        /// <summary>Gets or sets the office phone number.</summary>
        public string Phone { get; set; }

        /// <summary>Gets or sets the office fax number.</summary>
        public string Fax { get; set; }

        /// <summary>Gets or sets the office email address.</summary>
        public string Email { get; set; }

        /// <summary>Gets or sets the office address.</summary>
        public Address Address { get; set; }

        /// <summary>Gets or sets the office website URL.</summary>
        public string Website { get; set; }

        /// <summary>Gets or sets the office photo URL in S3 storage.</summary>
        public string Photo { get; set; }
    }
}