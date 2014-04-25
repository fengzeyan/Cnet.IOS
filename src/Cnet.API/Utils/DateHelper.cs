using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cnt.API.Utils
{
    /// <summary>Class that contains helper functions for helping with dates.</summary>
    public static class DateHelper
    {
        #region DateDiff

        /// <summary>Calculates the difference between two dates.</summary>
        /// <param name="part">The part of the date to return the date difference as.</param>
        /// <param name="date1">The date to subtract from.</param>
        /// <param name="date2">The date to subtract from <paramref name="date1"/>.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to use.</param>
        /// <returns>The difference between the two dates, in the part specified.</returns>
        /// <exception cref="ArgumentException"><paramref name="part"/> is not a valid <see cref="DatePart"/> value.</exception>
        public static long DateDiff(DatePart part, DateTimeOffset date1, DateTimeOffset date2, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }

            Calendar calendar = culture.Calendar;
            switch (part)
            {
                case DatePart.Year:
                    return (long)checked(calendar.GetYear(date2.DateTime) - calendar.GetYear(date1.DateTime));

                case DatePart.Quarter:
                    return (long)checked((calendar.GetYear(date2.DateTime) - calendar.GetYear(date1.DateTime)) * 4 + unchecked(checked(calendar.GetMonth(date2.DateTime) - 1) / 3) - unchecked(checked(calendar.GetMonth(date1.DateTime) - 1) / 3));

                case DatePart.Month:
                    return (long)checked((calendar.GetYear(date2.DateTime) - calendar.GetYear(date1.DateTime)) * 12 + calendar.GetMonth(date2.DateTime) - calendar.GetMonth(date1.DateTime));

                // This method treats both "week of year" and "weekday" as simply "weeks".
                case DatePart.WeekOfYear:
                case DatePart.Weekday:
                    // Get the first day of each week and subtract them.
                    date1 = date1.AddDays(((int)date1.DayOfWeek * -1) + (int)culture.DateTimeFormat.FirstDayOfWeek);
                    date2 = date2.AddDays(((int)date2.DayOfWeek * -1) + (int)culture.DateTimeFormat.FirstDayOfWeek);
                    return checked((long)Math.Round(DateHelper._Fix(date2.Subtract(date1).TotalDays))) / 7L;

                case DatePart.Iso8601WeekNumber:
                    // Get the first day of each week (ISO-8601 weeks always start on Monday) and subtract them.
                    date1 = date1.AddDays(((int)date1.DayOfWeek * -1) + (int)DayOfWeek.Monday);
                    date2 = date2.AddDays(((int)date2.DayOfWeek * -1) + (int)DayOfWeek.Monday);
                    return checked((long)Math.Round(DateHelper._Fix(date2.Subtract(date1).TotalDays))) / 7L;

                // This method treats both "days of month" and "days of year" as simply "days".
                case DatePart.DayOfMonth:
                case DatePart.DayOfYear:
                    return checked((long)Math.Round(DateHelper._Fix(date2.Subtract(date1).TotalDays)));

                case DatePart.Hour:
                    return checked((long)Math.Round(DateHelper._Fix(date2.Subtract(date1).TotalHours)));

                case DatePart.Minute:
                    return checked((long)Math.Round(DateHelper._Fix(date2.Subtract(date1).TotalMinutes)));

                case DatePart.Second:
                    return (long)checked(Math.Round(DateHelper._Fix(date2.Subtract(date1).TotalSeconds)));

                case DatePart.Millisecond:
                    return (long)checked(Math.Round(DateHelper._Fix(date2.Subtract(date1).TotalMilliseconds)));

                case DatePart.Microsecond:
                    // 1 tick == 10 microseconds
                    return checked(date2.Subtract(date1).Ticks / 10L);

                case DatePart.Nanosecond:
                    // 1 tick == 100 nanoseconds, which is the highest precision supported by the .NET DateTime object.
                    return checked(date2.Subtract(date1).Ticks * 100L);

                case DatePart.Ticks:
                    return date2.Subtract(date1).Ticks;

                case DatePart.TimeZoneOffset:
                    return (long)checked(Math.Round(DateHelper._Fix(date2.Offset.Subtract(date1.Offset).TotalMinutes)));

                default:
                    throw new ArgumentException("Not a valid Onsharp.DatePart value.", "part");
            }
        }

        private static double _Fix(double value)
        {
            if (value >= 0.0)
            {
                return Math.Floor(value);
            }

            return -Math.Floor(-value);
        }

        #endregion

        #region N-Day Calculations

        /// <summary>Calculates the Nth weekday of the given month of the given year, for example, the 3rd Monday of May.</summary>
        /// <param name="nthValue">The Nth occurrence of the weekday in the month.</param>
        /// <param name="weekday">The weekday.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>A <see cref="DateTime"/> that contains the date of the Nth weekday of the given month of the given year, or null if the day does not exist in the specified month and year.</returns>
        /// <exception cref="ArgumentException"><paramref name="weekday"/> is not a valid <see cref="DayOfWeek"/> value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="nthValue"/> is less than 1 or greater than 5 (never more than 5 instances of any day of the week in any month).<br />
        /// - or -<br />
        /// <paramref name="year"/> is less than 1 or greater than 9999.<br />
        /// - or -<br />
        /// <paramref name="month"/> is less than 1 or greater than 12.<br />
        /// </exception>
        public static DateTime? NthDay(int nthValue, DayOfWeek weekday, int month, int year)
        {
            if (nthValue < 1 || nthValue > 5)
            {
                throw new ArgumentOutOfRangeException("nthValue", "The \"Nth\" value must be a value between 1 and 5.");
            }

            DateTime nthDate = new DateTime(year, month, 1);
            int offset = weekday - nthDate.DayOfWeek;
            int day = nthDate.Day + (offset + (nthValue - (offset >= 0 ? 1 : 0)) * 7);
            if (day > DateTime.DaysInMonth(year, month))
            {
                return null;
            }

            return new DateTime(year, month, day);
        }

        /// <summary>Calculates the last occurrence of a weekday in the given month of the given year.</summary>
        /// <param name="weekday">The weekday.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>A <see cref="DateTime"/> that contains the date of the last occurrence of the given weekday in the given month of the given year.</returns>
        /// <exception cref="ArgumentException"><paramref name="weekday"/> is not a valid <see cref="DayOfWeek"/> value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="year"/> is less than 1 or greater than 9999.<br />
        /// - or -<br />
        /// <paramref name="month"/> is less than 1 or greater than 12.<br />
        /// </exception>
        public static DateTime LastNDay(DayOfWeek weekday, int month, int year)
        {
            DateTime lastDay = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            return lastDay.AddDays(weekday - lastDay.DayOfWeek - (weekday > lastDay.DayOfWeek ? 7 : 0));
        }

        #endregion

		#region DateTime Extensions

		#region DaysOfWeek and DayOfWeek Extensions

		/// <summary>Gets a value indicating if the specified <see cref="DayOfWeek"/> value is contained in the specified <see cref="DaysOfWeek"/> value.</summary>
		/// <param name="days">The <see cref="DaysOfWeek"/> value to check if <paramref name="value"/> is contained.</param>
		/// <param name="value">The <see cref="DayOfWeek"/> value to check if <paramref name="days"/> contains.</param>
		/// <returns>A value indicating if <paramref name="value"/> is included in <paramref name="days"/>.</returns>
		public static bool ContainsDayOfWeek(this DaysOfWeek days, DayOfWeek value)
		{
			// value is converted to a DaysOfWeek value by the following formula:
			// 2 ^ x
			// Where x is the integer value of of the DayOfWeek value (where 0 = Sun, 1 = Mon, 2 = Tues, 3 = Wed, etc)
			// This will result in 1 = Sun, 2 = Mon, 4 = Tues, 8 = Wed, etc.

			int day = (int)Math.Pow(2D, (double)value);
			return (day & (int)days) == day;
		}

		/// <summary>Converts the specified <see cref="DayOfWeek"/> value to a <see cref="DaysOfWeek"/> value.</summary>
		/// <param name="value">The <see cref="DayOfWeek"/> value to convert.</param>
		/// <returns>The specified <see cref="DayOfWeek"/> value converted to a <see cref="DaysOfWeek"/> value.</returns>
		public static DaysOfWeek ConvertToDaysOfWeek(this DayOfWeek value)
		{
			// value is converted to a DaysOfWeek value by the following formula:
			// 2 ^ x
			// Where x is the integer value of of the DayOfWeek value (where 0 = Sun, 1 = Mon, 2 = Tues, 3 = Wed, etc)
			// This will result in 1 = Sun, 2 = Mon, 4 = Tues, 8 = Wed, etc.

			return (DaysOfWeek)(int)Math.Pow(2D, (double)value);
		}

		#endregion

		/// <summary>Gets the first day of the week that the specified date resides in.</summary>
		/// <param name="date">The date to get the first day of the week for.</param>
		/// <returns>The first day of the week that the specified date resides in.</returns>
		public static DateTime FirstWeekday(this DateTime date)
		{
			return FirstWeekday(date, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
		}

		/// <summary>Gets the first day of the week that the specified date resides in.</summary>
		/// <param name="date">The date to get the first day of the week for.</param>
		/// <param name="firstDayOfWeek">The first day of the week.</param>
		/// <returns>The first day of the week that the specified date resides in.</returns>
		public static DateTime FirstWeekday(this DateTime date, DayOfWeek firstDayOfWeek)
		{
			int delta = (int)date.DayOfWeek - (int)firstDayOfWeek;
			if (delta < 0)
			{
				delta += 7;
			}

			return date.AddDays(-delta);
		}

		/// <summary>Gets the last day of the week that the specified date resides in.</summary>
		/// <param name="date">The date to get the last day of the week for.</param>
		/// <returns>The last day of the week that the specified date resides in.</returns>
		public static DateTime LastWeekday(this DateTime date)
		{
			return LastWeekday(date, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
		}

		/// <summary>Gets the last day of the week that the specified date resides in.</summary>
		/// <param name="date">The date to get the last day of the week for.</param>
		/// <param name="firstDayOfWeek">The first day of the week.</param>
		/// <returns>The last day of the week that the specified date resides in.</returns>
		public static DateTime LastWeekday(this DateTime date, DayOfWeek firstDayOfWeek)
		{
			// Use the same calculation as for the first weekday, but add 6 days.
			int delta = (int)date.DayOfWeek - (int)firstDayOfWeek;
			if (delta < 0)
			{
				delta += 7;
			}

			return date.AddDays(-delta + 6);
		}

		/// <summary>Gets a value indicating if the year of the specified date is a leap year.</summary>
		/// <param name="date">The date to check.</param>
		/// <param name="culture">The <see cref="CultureInfo"/> to use.</param>
		/// <returns>A value indicating if the year of the specified date is a leap year.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="date"/> is outside the range supported by the current culture's calendar.</exception>
		public static bool IsLeapYear(this DateTime date, CultureInfo culture)
		{
			return (culture ?? CultureInfo.CurrentCulture).Calendar.IsLeapYear(date.Year);
		}

		#endregion

		#region Enum Extensions

		/// <summary>Converts an enumeration value (usually a Flags enumeration) to an array of the values that have been selected.</summary>
		/// <param name="value">The enumeration value to convert to an array. Can be null.</param>
		/// <returns>An array of the selected (non-zero) enumeration values.</returns>
		/// <exception cref="InvalidCastException">The enumeration value could not be converted to an <see cref="UInt64"/>.</exception>
		/// <remarks>
		/// <note type="important">Enumerations with negative values are not supported by this method.</note>
		/// <note type="caution">This method uses reflection and is not optimized for speed, and so should not be used in places where speed is a factor.</note>
		/// </remarks>
		public static ulong[] ToArray(this Enum value)
		{
			if (value == null)
			{
				return new ulong[] { };
			}

			ulong valueAsUInt64 = Convert.ToUInt64(value, null);
			List<ulong> list = new List<ulong>();
			foreach (var item in Enum.GetValues(value.GetType()))
			{
				ulong itemAsUInt64 = Convert.ToUInt64(item, null);
				if (itemAsUInt64 > 0 && (itemAsUInt64 & valueAsUInt64) == itemAsUInt64)
				{
					list.Add(itemAsUInt64);
				}
			}

			return list.ToArray();
		}

		#endregion
	}

	/// <summary>Represents the parts of a date.</summary>
	public enum DatePart
	{
		/// <summary>No date part specified.</summary>
		None = 0,

		/// <summary>Year part of the date.</summary>
		Year = 1,

		/// <summary>Quarter of the date.</summary>
		Quarter = 2,

		/// <summary>Month part of the date.</summary>
		Month = 3,

		/// <summary>Day of month of the date.</summary>
		DayOfMonth = 4,

		/// <summary>Day of year of the date.</summary>
		DayOfYear = 5,

		/// <summary>Weekday of the date.</summary>
		Weekday = 6,

		/// <summary>Week of year (calendar week) of the date.</summary>
		WeekOfYear = 7,

		/// <summary>ISO-8601 week number of the date.</summary>
		Iso8601WeekNumber = 8,

		/// <summary>Hour part of the date.</summary>
		Hour = 9,

		/// <summary>Minute part of the date.</summary>
		Minute = 10,

		/// <summary>Second part of the date.</summary>
		Second = 11,

		/// <summary>Millisecond part of the date.</summary>
		Millisecond = 12,

		/// <summary>Microsecond part of the date.</summary>
		Microsecond = 13,

		/// <summary>Nanosecond part of the date.</summary>
		Nanosecond = 14,

		/// <summary>Ticks part of the date.</summary>
		Ticks = 15,

		/// <summary>Time zone offset part of the date (usually in number of minutes).</summary>
		TimeZoneOffset = 16
	}

	/// <summary>Represents the days of the week, in an enumeration where more than one day of the week can be specified.</summary>
	[Flags]
	public enum DaysOfWeek
	{
		/// <summary>Indicates all days of the week.</summary>
		All = Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday,

		/// <summary>Indicates the week day days of the week (Monday, Tuesday, Wednesday, Thursday, Friday).</summary>
		Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,

		/// <summary>Indicates the weekend days of the week (Sunday, Saturday).</summary>
		Weekend = Sunday | Saturday,

		/// <summary>No days of the week have been specified.</summary>
		None = 0,

		/// <summary>Indicates Sunday.</summary>
		Sunday = 1,

		/// <summary>Indicates Monday.</summary>
		Monday = 2,

		/// <summary>Indicates Tuesday.</summary>
		Tuesday = 4,

		/// <summary>Indicates Wednesday.</summary>
		Wednesday = 8,

		/// <summary>Indicates Thursday.</summary>
		Thursday = 16,

		/// <summary>Indicates Friday.</summary>
		Friday = 32,

		/// <summary>Indicates Saturday.</summary>
		Saturday = 64
	}
}