using System;

namespace Cnt.Web.API.Models
{
    /// <summary>Represents a schedule for a placement.</summary>
    public class Schedule
    {
		/// <summary>Gets or sets the schedule ID.</summary>
		public int Id { get; set; }

		/// <summary>Gets or sets the parent schedule ID the schedule is associated with.</summary>
		public int ParentId { get; set; }

        /// <summary>Gets or sets the start date of the schedule (although not necessarily the date of the first occurrence of the schedule).</summary>
        public DateTime StartDate { get; set; }

        /// <summary>Gets or sets the time and duration of the schedule. If null, the schedule is assumed to occur all day.</summary>
        public TimeBlock Time { get; set; }

        /// <summary>Gets or sets the repeat type of the schedule. Possible values: "None" (default), "Daily", "Weekly"m "Monthly", and "Yearly".</summary>
        public string RepeatType { get; set; }

        /// <summary>Gets or sets the N value used for daily, weekly, and monthly repeat types (every N days, weeks, or months).</summary>
        public int NValue { get; set; }

        /// <summary>Gets or sets a comma delimited list of day names used for the weekly repeat type. Possible values: "Sunday" (default), "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", and "Saturday".</summary>
        public string WeeklyDays { get; set; }

        /// <summary>Gets or sets the day of the month used for monthly and yearly repeat types. Values 31 and greater will use the last day of the month. Zero value will use the first day of the month.</summary>
        public byte DayOfMonth { get; set; }

        /// <summary>Gets or sets the monthly repeat type. Possible values: "SpecificDayOfMonth" (default) and "SpecificNumberedDayOfWeek".</summary>
        public string MonthlyRepeatType { get; set; }

        /// <summary>Gets or sets the day of the week used for the monthly repeat types. Possible values: "Sunday" (default), "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", and "Saturday".</summary>
        public string MonthlyDayOfWeek { get; set; }

        /// <summary>Gets or sets the monthly repeat N week value (Nth week of the month). Values 5 and greater will use the last week of the month. Zero value will use the first week of the month.</summary>
        public byte MonthlyNWeek { get; set; }

        /// <summary>Gets or sets the yearly repeat month. 1 = Jan, 2 = Feb, 3 = March, and so on.</summary>
        public byte YearlyMonth { get; set; }

        /// <summary>Gets or sets the end type of the schedule. Possible values: "None" (default), "AfterSpecifiedNumberOfOccurrences", and "AfterSpecifiedDate".</summary>
        public string EndType { get; set; }

        /// <summary>Gets or sets the number of times the schedule occurs, used for the "AfterSpecifiedNumberOfOccurrences" end type.</summary>
        public int EndNCount { get; set; }

        /// <summary>Gets or sets the end date, used for the "AfterSpecifiedDate" end type.</summary>
        public DateTime? EndDate { get; set; }

        /// <summary>Gets or sets a value indicating if the schedule is canceled.</summary>
        public bool IsCanceled { get; set; }
    }
}