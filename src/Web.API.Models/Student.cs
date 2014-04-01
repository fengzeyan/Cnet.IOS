using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a student/child associated with a placement.</summary>
    public class Student
    {
        /// <summary>Gets or sets the student's name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the student's gender.</summary>
        public string Gender { get; set; }

        /// <summary>Gets or sets the student's date of birth.</summary>
        public DateTime? DateOfBirth { get; set; }
    }
}