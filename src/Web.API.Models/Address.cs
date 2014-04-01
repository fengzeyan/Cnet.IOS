using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents an address.</summary>
    public class Address
    {
        /// <summary>Gets or sets the address line 1.</summary>
        public string Line1 { get; set; }

        /// <summary>Gets or sets the address line 2.</summary>
        public string Line2 { get; set; }

        /// <summary>Gets or sets the address line 3.</summary>
        public string Line3 { get; set; }

        /// <summary>Gets or sets the address city.</summary>
        public string City { get; set; }

        /// <summary>Gets or sets the address state (two letter abbreviation).</summary>
        public string State { get; set; }

        /// <summary>Gets or sets the address zip code.</summary>
        public string Zip { get; set; }
    }
}