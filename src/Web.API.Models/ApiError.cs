using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents an error that occurs in the API.</summary>
    public class ApiError
    {
        /// <summary>Gets or sets the severity of the error.</summary>
        public int Severity { get; set; }

        /// <summary>Gets or sets the error code.</summary>
        public int Code { get; set; }

        /// <summary>Gets or sets the error message.</summary>
        public string Message { get; set; }
    }
}