using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents the severity of an API error.</summary>
    public enum ApiErrorSeverity
    {
        /// <summary>Use the default message severity. Not returned to the API caller and is for internal use only.</summary>
        Default = 0,

        /// <summary>The message is a debug level message. Usually these error messages are not returned to the API caller and are for internal use only.</summary>
        Debug = 1,

        /// <summary>The message is for informational purposes only. Usually these error messages are not returned to the API caller and are for internal use only.</summary>
        Information = 2,

        /// <summary>The message represents a validation error that the user must correct.</summary>
        Validation = 3,

        /// <summary>The message represents a user level error that the user must correct.</summary>
        UserError = 4,

        /// <summary>The message represents a system level error, usually errors that can not be corrected by the user and don't stop execution of the application.</summary>
        SystemError = 5,

        /// <summary>The message represents a fatal system error, usually errors that stop execution of the application and prevent the application from continuing.</summary>
        FatalError = 6,
    }
}