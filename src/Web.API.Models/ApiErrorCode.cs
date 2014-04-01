using System;
using System.ComponentModel;
//using Onsharp;
//using Onsharp.ComponentModel;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents the API error codes.</summary>
    //[TypeConverter(typeof(EnumDescriptionConverter))]
    public enum ApiErrorCode
    {
        /// <summary>No error code specified.</summary>
        None = 0,

        /// <summary>General or unknown error.</summary>
        [Description("General Error")]//, DefaultMessage("A general or unknown error occurred.")]
        GeneralError = 1,

        /// <summary>System error.</summary>
        [Description("System Error")]//, DefaultMessage("An internal system error occurred.")]
        SystemError = 2,

        /// <summary>An error that the user must correct.</summary>
        [Description("User Fault Error")]//, DefaultMessage("A user error occurred. Please correct the error and try again.")]
        UserFaultError = 3,

        /// <summary>A validation error that the user must correct.</summary>
        [Description("Validation Error")]//, DefaultMessage("A validation error occurred. Please correct the error and try again.")]
        ValidationError = 4,

        /// <summary>Insufficient permissions to perform the requested action.</summary>
        [Description("Permission Error")]//, DefaultMessage("Insufficient permissions to perform the requested action.")]
        PermissionError = 5,

        /// <summary>I/O interaction error. Usually caused by invalid I/O permissions or an I/O device not being available.</summary>
        [Description("I/O Error")]//, DefaultMessage("An I/O error occurred when attempting to perform the requested operation.")]
        IOError = 6,

        /// <summary>Database interaction error. Usually caused by an SQL timeout/deadlock.</summary>
        [Description("Database Error")]//, DefaultMessage("A database error occurred when attempting to perform the requested operation. Please wait 5 minutes and try again.")]
        DatabaseError = 7,

        /// <summary>Unable to load an object's data and/or details.</summary>
        [Description("Object Load Error")]//, DefaultMessage("Unable to load an object's data and/or details.")]
        ObjectLoadError = 8,

        /// <summary>The specified object was not found in the data records.</summary>
        [Description("Object Not Found")]//, DefaultMessage("The specified object was not found in the data records.")]
        ObjectNotFound = 9,

        /// <summary>Unable to send an email.</summary>
        [Description("Email Send Error")]//, DefaultMessage("Unable to send an email. Ensure the email addresses are valid email addresses.")]
        EmailSendError = 10,

        /// <summary>Invalid parameter.</summary>
        [Description("Invalid Parameter")]//, DefaultMessage("A parameter value is invalid.")]
        ParameterInvalid = 11
    }
}