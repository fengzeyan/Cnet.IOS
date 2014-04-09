using Cnt.Web.API.Models;
using System;
using System.Collections.Generic;

namespace Cnt.API.Utils
{
	/// <summary>Wrapper class that provides advanced scheduling functionality.</summary>
	public class AdvanceSchedule
	{
		private DateTime _StartDate;
		private TimeSpan? _StartTime;
		private short _Duration;
		private ScheduleRepeatType _RepeatType;
		private int _NValue;
		private DaysOfWeek _WeeklyDays;
		private byte _DayOfMonth;
		private ScheduleMonthlyRepeatType _MonthlyRepeatType;
		private DayOfWeek _MonthlyDayOfWeek;
		private byte _MonthlyNWeek;
		private byte _YearlyMonth;
		private int _EndNCount;
		private ScheduleEndType _EndType;
		private DateTime? _EndDate;

		private bool _RecalculateFirstOccurrence;
		private bool _RecalculateLastOccurrence;
		private bool _IsCalculatingLast;
		private DateTime? _FirstOccurrence;
		private DateTime? _LastOccurrence;
		private Dictionary<long, DateTime?> _NextCache;
		private Dictionary<long, DateTime?> _PreviousCache;

		/// <summary>Initializes a new instance of the <see cref="AdvanceSchedule"/> class.</summary>
		public AdvanceSchedule()
		{
			this._NValue = 1;
			this._DayOfMonth = 1;
			this._MonthlyNWeek = 1;
			this._YearlyMonth = 1;
			this._EndNCount = 1;
			this._RecalculateFirstOccurrence = true;
			this._RecalculateLastOccurrence = true;
			this._NextCache = new Dictionary<long, DateTime?>();
			this._PreviousCache = new Dictionary<long, DateTime?>();
		}

		/// <summary>Initializes a new instance of the <see cref="AdvanceSchedule" /> class.</summary>
		/// <param name="schedule">The schedule.</param>
		public AdvanceSchedule(Schedule schedule) : this()
		{
			this._DayOfMonth = schedule.DayOfMonth;
			this._EndDate = schedule.EndDate;
			this._EndNCount = schedule.EndNCount;
			this.IsCanceled = schedule.IsCanceled;
			this._MonthlyNWeek = schedule.MonthlyNWeek;
			this._NValue = schedule.NValue;
			this._StartDate = schedule.StartDate;
			this._StartTime = new TimeSpan(schedule.Time.Start * TimeSpan.TicksPerSecond);
			this._YearlyMonth = schedule.YearlyMonth;

			ScheduleEndType endType;
			if (Enum.TryParse<ScheduleEndType>(schedule.EndType, out endType) && (Enum.IsDefined(typeof(ScheduleEndType), endType) | endType.ToString().Contains(",")))
				this._EndType = endType;

			DayOfWeek monthlyDayOfWeek;
			if (Enum.TryParse<DayOfWeek>(schedule.MonthlyDayOfWeek, out monthlyDayOfWeek) && (Enum.IsDefined(typeof(DayOfWeek), monthlyDayOfWeek) | monthlyDayOfWeek.ToString().Contains(",")))
				this._MonthlyDayOfWeek = monthlyDayOfWeek;

			ScheduleMonthlyRepeatType monthlyRepeatType;
			if (Enum.TryParse<ScheduleMonthlyRepeatType>(schedule.MonthlyRepeatType, out monthlyRepeatType) && (Enum.IsDefined(typeof(ScheduleMonthlyRepeatType), monthlyRepeatType) | monthlyRepeatType.ToString().Contains(",")))
				this._MonthlyRepeatType = monthlyRepeatType;

			ScheduleRepeatType repeatType;
			if (Enum.TryParse<ScheduleRepeatType>(schedule.RepeatType, out repeatType) && (Enum.IsDefined(typeof(ScheduleRepeatType), repeatType) | repeatType.ToString().Contains(",")))
				this._RepeatType = repeatType;

			DaysOfWeek weeklyDays;
			if (Enum.TryParse<DaysOfWeek>(schedule.WeeklyDays, out weeklyDays) && (Enum.IsDefined(typeof(DaysOfWeek), weeklyDays) | weeklyDays.ToString().Contains(",")))
				this._WeeklyDays = weeklyDays;
		}

		#region Properties

		/// <summary>
		/// Gets or sets a value indicating if the first occurrence should be re-calculated if <see cref="FirstOccurrence"/> is called instead of
		/// using the cached value.
		/// </summary>
		protected bool RecalculateFirstOccurrence
		{
			get { return this._RecalculateFirstOccurrence; }
			set
			{
				if (value != this._RecalculateFirstOccurrence)
				{
					if (value == true)
					{
						// Dates in the caches could no longer be valid, clear our caches.
						this._NextCache.Clear();
						this._PreviousCache.Clear();
					}

					this._RecalculateFirstOccurrence = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating if the last occurrence should be re-calculated if <see cref="LastOccurrence"/> is called instead of
		/// using the cached value.
		/// </summary>
		protected bool RecalculateLastOccurrence
		{
			get { return this._RecalculateLastOccurrence; }
			set
			{
				if (value != this._RecalculateLastOccurrence)
				{
					if (value == true)
					{
						// Dates in the caches could no longer be valid, clear our caches.
						this._NextCache.Clear();
						this._PreviousCache.Clear();
					}

					this._RecalculateLastOccurrence = value;
				}
			}
		}

		/// <summary>Gets or sets the schedule start date.</summary>
		public virtual DateTime StartDate
		{
			get { return this._StartDate; }
			set
			{
				if (value != this._StartDate)
				{
					this._StartDate = value.Date;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the start time of the scheduled item, if there is one.</summary>
		/// <exception cref="ArgumentOutOfRangeException">The property is being set and <paramref name="value"/> does not represent a time between 00:00 and 23:59.</exception>
		public virtual TimeSpan? StartTime
		{
			get { return this._StartTime; }
			set
			{
				// 1439 minutes = 23 hours, 59 minutes.
				if (value != null && (value.Value.TotalMinutes < 0D || value.Value.TotalMinutes > 1439D))
				{
					throw new ArgumentOutOfRangeException("value", "Must represent a time between 00:00 and 23:59.");
				}

				this._StartTime = value;
			}
		}

		/// <summary>Gets or sets the number of minutes that the scheduled item will occur for each time it occurs.</summary>
		/// <exception cref="ArgumentOutOfRangeException">The property is being set and <paramref name="value"/> is negative.</exception>
		public virtual short Duration
		{
			get { return this._Duration < 0 ? (short)0 : this._Duration; }
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", "Can not be negative.");
				}

				this._Duration = value;
			}
		}

		/// <summary>Gets the end time of the scheduled item, if there is one.</summary>
		public virtual TimeSpan? EndTime
		{
			get
			{
				if (this.StartTime != null && this.Duration > 0)
				{
					return TimeSpan.FromMinutes(this.StartTime.Value.TotalMinutes + this.Duration);
				}

				return null;
			}
		}

		/// <summary>Gets or sets the schedule repeat type.</summary>
		public virtual ScheduleRepeatType RepeatType
		{
			get { return this._RepeatType; }
			set
			{
				if (value != this._RepeatType)
				{
					this._RepeatType = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the N value used for daily, weekly, and monthly repeat types (every N days, weeks, or months).</summary>
		/// <exception cref="ArgumentOutOfRangeException">The property is being set and <paramref name="value"/> is less than or equal to zero.</exception>
		public virtual int NValue
		{
			get { return this._NValue < 1 ? 1 : this._NValue; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("value", "Must be greater than zero.");
				}

				if (value != this._NValue)
				{
					this._NValue = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the days of the week used for the weekly repeat types.</summary>
		public virtual DaysOfWeek WeeklyDays
		{
			get { return this._WeeklyDays; }
			set
			{
				if (value != this._WeeklyDays)
				{
					this._WeeklyDays = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the day of the month used for monthly and yearly repeat types. Use <see cref="byte.MaxValue"/> for the last day of the month.</summary>
		/// <exception cref="ArgumentOutOfRangeException">The property is being set and <paramref name="value"/> is less than or equal to zero.</exception>
		public virtual byte DayOfMonth
		{
			get { return this._DayOfMonth < 1 ? (byte)1 : this._DayOfMonth; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("value", "Must be greater than zero.");
				}

				if (value != this._DayOfMonth)
				{
					this._DayOfMonth = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the monthly repeat type.</summary>
		public virtual ScheduleMonthlyRepeatType MonthlyRepeatType
		{
			get { return this._MonthlyRepeatType; }
			set
			{
				if (value != this._MonthlyRepeatType)
				{
					this._MonthlyRepeatType = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the day of the week used for the monthly repeat types.</summary>
		public virtual DayOfWeek MonthlyDayOfWeek
		{
			get { return this._MonthlyDayOfWeek; }
			set
			{
				if (value != this._MonthlyDayOfWeek)
				{
					this._MonthlyDayOfWeek = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the monthly repeat N week value (Nth week of the month). Use <see cref="byte.MaxValue"/> for the last week of the month.</summary>
		/// <exception cref="ArgumentOutOfRangeException">The property is being set and <paramref name="value"/> is less than or equal to zero.</exception>
		public virtual byte MonthlyNWeek
		{
			get
			{
				if (this._MonthlyNWeek < 1)
				{
					return 1;
				}
				else if (this._MonthlyNWeek > 5)
				{
					return 5;
				}

				return this._MonthlyNWeek;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("value", "Must be greater than zero.");
				}

				if (value > 5)
				{
					value = 5;
				}

				if (value != this._MonthlyNWeek)
				{
					this._MonthlyNWeek = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the yearly repeat month. 1 = Jan, 2 = Feb, 3 = March, and so on.</summary>
		/// <exception cref="ArgumentOutOfRangeException">The property is being set and <paramref name="value"/> is not a value between 1 and 12 (inclusive).</exception>
		public virtual byte YearlyMonth
		{
			get
			{
				if (this._YearlyMonth < 1)
				{
					return 1;
				}
				else if (this._YearlyMonth > 12)
				{
					return 12;
				}

				return this._YearlyMonth;
			}
			set
			{
				if (value < 1 || value > 12)
				{
					throw new ArgumentOutOfRangeException("value", "Must be a value between 1 and 12.");
				}

				if (value != this._YearlyMonth)
				{
					this._YearlyMonth = value;
					this.RecalculateFirstOccurrence = true;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the schedule end type.</summary>
		public virtual ScheduleEndType EndType
		{
			get { return this._EndType; }
			set
			{
				if (value != this._EndType)
				{
					this._EndType = value;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the end occurrence count, used when <see cref="ScheduleEndType.AfterSpecificNumberOfOccurrences"/> is specified.</summary>
		/// <exception cref="ArgumentOutOfRangeException">The property is being set and <paramref name="value"/> is less than or equal to zero.</exception>
		public virtual int EndNCount
		{
			get { return this._EndNCount < 1 ? 1 : this._EndNCount; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("value", "Must be greater than zero.");
				}

				if (value != this._EndNCount)
				{
					this._EndNCount = value;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets the end date, used when <see cref="ScheduleEndType.AfterSpecificDate"/> is specified.</summary>
		public virtual DateTime? EndDate
		{
			get { return this._EndDate; }
			set
			{
				if (value != this._EndDate)
				{
					this._EndDate = value != null ? value.Value.Date : value;
					this.RecalculateLastOccurrence = true;
				}
			}
		}

		/// <summary>Gets or sets a value indicating if the schedule is canceled.</summary>
		public virtual bool IsCanceled
		{
			get;
			set;
		}

		/// <summary>Gets or sets a value indicating if the schedule takes place over the entire day (midnight to midnight).</summary>
		public bool AllDay
		{
			get { return this.StartTime != null && this.StartTime.Value.TotalSeconds == 0 && this.Duration == 1440; } // 1440 minutes = 24 hours.
			set
			{
				if (value)
				{
					this.StartTime = new TimeSpan(0, 0, 0); // Set to midnight.
					this.Duration = 1440; // 24 hour duration.
				}
				else
				{
					// Set to no start time and no duration.
					this.StartTime = null;
					this.Duration = 0;
				}
			}
		}

		#endregion

		#region Date Occurrence Calculation

		/// <summary>Gets the first date that the schedule will (or did) occur at.</summary>
		/// <returns>The first date that the schedule will (or did) occur at.</returns>
		/// <exception cref="InvalidOperationException">No start date has been specified.</exception>
		public DateTime FirstOccurrence()
		{
			// Method Dependencies:
			// - _CalculateNextWeeklyOccurrence()
			// - _CalculateNextMonthlyOccurrence()
			// - _CalculateNextYearlyOccurrence()

			if (this.StartDate == default(DateTime))
			{
				throw new InvalidOperationException("No start date has been specified.");
			}

			// If the first occurrence has already been calculated, then return the calculated date.
			if (!this.RecalculateFirstOccurrence)
			{
				return this._FirstOccurrence.Value;
			}

			try
			{
				switch (this.RepeatType)
				{
					default:
					case ScheduleRepeatType.None:
					case ScheduleRepeatType.Daily:
						// The start date is the first occurrence.
						this._FirstOccurrence = this.StartDate;
						break;

					case ScheduleRepeatType.Weekly:
						this._FirstOccurrence = this._CalculateNextWeeklyOccurrence(this.StartDate, false);
						break;

					case ScheduleRepeatType.Monthly:
						this._FirstOccurrence = this._CalculateNextMonthlyOccurrence(this.StartDate);
						break;

					case ScheduleRepeatType.Yearly:
						this._FirstOccurrence = this._CalculateNextYearlyOccurrence(this.StartDate);
						break;
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				// The calculations resulted in an invalid date - just use the start date as the first occurrence.
				this._FirstOccurrence = this.StartDate;
			}

			if (this._FirstOccurrence == null)
			{
				// The calculations were unable to determine the start date, use the start date as the first occurrence.
				this._FirstOccurrence = this.StartDate;
			}

			this._FirstOccurrence = this._FirstOccurrence.Value.Date; // We only want the date value.
			this.RecalculateFirstOccurrence = false;
			return this._FirstOccurrence.Value;
		}

		/// <summary>Gets the next date this schedule will occur after the specified <paramref name="from"/> date.</summary>
		/// <param name="from">The date the next occurrence date will be calculated from. Defaults to <see cref="DateTime.Today"/>.</param>
		/// <returns>
		/// The next date the schedule will occur after the specified <paramref name="from"/> date, or <see langword="null"/> if the
		/// schedule will not occur again after <paramref name="from"/>.
		/// </returns>
		/// <exception cref="InvalidOperationException">
		/// No start date has been specified.<br />
		/// - or -<br />
		/// <see cref="EndType"/> is <see cref="ScheduleEndType.AfterSpecificDate"/> and no end date has been specified.
		/// </exception>
		public DateTime? NextOccurrence(DateTime from)
		{
			// Method Dependencies:
			// - FirstOccurrence()
			// - LastOccurrence()
			// - PreviousOccurrence() [From LastOccurrence()]
			// - _CalculateNDay()
			// - _CalculateNWeek()
			// - _CalculateNMonth()
			// - _CalculateNextWeeklyOccurrence()
			// - _CalculateNextMonthlyOccurrence()
			// - _CalculateNextYearlyOccurrence()
			// - _MonthlyEnsureLastDayOfMonth() [From PreviousOccurrence()]
			// - _MonthlyEnsureNthWeekDay() [From PreviousOccurrence()]

			if (this.StartDate == default(DateTime))
			{
				throw new InvalidOperationException("No start date has been specified.");
			}

			// We don't care about time values, so just eliminate any times specified.
			from = from.Date;
			long v_ticks = from.Ticks;

			// If the next occurrence from the specified from date has already been calculated, then return the cached value.
			if (this._NextCache.ContainsKey(v_ticks))
			{
				return this._NextCache[v_ticks];
			}

			// Variable used throughout the calculations. Start with it equal to the first occurrence of the schedule.
			DateTime v_next_occurrence = this.FirstOccurrence();

			// If no from date is specified or if the from date is before the first occurrence, then the next date is the first occurrence.
			if (from == default(DateTime) || from < v_next_occurrence)
			{
				this._NextCache[v_ticks] = v_next_occurrence; // Add the value to the cache.
				return v_next_occurrence;
			}

			try
			{
				switch (this.RepeatType)
				{
					case ScheduleRepeatType.None:
						// If we get to this point, then the from date is greater than or equal to the start date, and since the schedule never
						// repeats, there is no next occurrence.
						this._NextCache[v_ticks] = null; // Add the value to the cache.
						return null;

					case ScheduleRepeatType.Daily:
						// Add a day so that the from date is not included in the calculations.
						v_next_occurrence = this._CalculateNDay(from.AddDays(1), false);
						break;

					case ScheduleRepeatType.Weekly:
						// Add a day so that the from date is not included in the calculations.
						v_next_occurrence = this._CalculateNWeek(this._CalculateNextWeeklyOccurrence(from.AddDays(1), false), false);
						break;

					case ScheduleRepeatType.Monthly:
						// Add a day so that the from date is not included in the calculations.
						v_next_occurrence = this._CalculateNMonth(this._CalculateNextMonthlyOccurrence(from.AddDays(1)), false);
						break;

					case ScheduleRepeatType.Yearly:
						// Add a day so that the from date is not included in the calculations.
						v_next_occurrence = this._CalculateNYear(this._CalculateNextYearlyOccurrence(from.AddDays(1)), false);
						break;
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				// The date calculations resulted in an invalid date, assume that the schedule will never occur again.
				this._NextCache[v_ticks] = null; // Add the value to the cache.
				return null;
			}

			// If the calculated date is after the date of the last occurrence, then this schedule will never occur again.
			DateTime? v_last_date = this.LastOccurrence();
			if (v_last_date != null && v_next_occurrence > v_last_date.Value)
			{
				this._NextCache[v_ticks] = null; // Add the value to the cache.
				return null;
			}

			v_next_occurrence = v_next_occurrence.Date; // We only care about the date part, trim off the time.
			this._NextCache[v_ticks] = v_next_occurrence; // Add the value to the cache.
			return v_next_occurrence;
		}

		/// <summary>Gets the previous date this schedule occurred on or before the specified <paramref name="from"/> date.</summary>
		/// <param name="from">The date the previous occurrence date will be calculated from. Defaults to <see cref="DateTime.Today"/>.</param>
		/// <returns>
		/// The previous date the schedule occurred on or before the specified <paramref name="from"/> date, or <see langword="null"/> if the
		/// schedule has not previously occurred on or before <paramref name="from"/>.
		/// </returns>
		/// <exception cref="InvalidOperationException">No start date has been specified.</exception>
		public DateTime? PreviousOccurrence(DateTime from)
		{
			// Method Dependencies:
			// - FirstOccurrence()
			// - LastOccurrence() [only if we are not in the process of calculating the last occurrence already, i.e. the _IsCalculatingLast flag must be false]
			// - _CalculateNDay()
			// - _CalculateNWeek()
			// - _CalculateNMonth()
			// - _CalculateNextWeeklyOccurrence()
			// - _CalculateNextMonthlyOccurrence()
			// - _CalculateNextYearlyOccurrence()
			// - _MonthlyEnsureLastDayOfMonth()
			// - _MonthlyEnsureNthWeekDay()

			if (this.StartDate == default(DateTime))
			{
				throw new InvalidOperationException("No start date has been specified.");
			}

			// We don't care about time values, so just eliminate any times specified.
			from = from.Date;
			long v_ticks = from.Ticks;

			// If the previous occurrence from the specified from date has already been calculated, then return the cached value.
			if (this._PreviousCache.ContainsKey(v_ticks))
			{
				return this._PreviousCache[v_ticks];
			}

			if (from == default(DateTime) || from < this.StartDate)
			{
				// There is no previous occurrence.
				this._PreviousCache[v_ticks] = null; // Add the value to the cache.
				return null;
			}

			DateTime v_first_occurrence = this.FirstOccurrence();
			if (from < v_first_occurrence)
			{
				// If the from date is before the first occurrence of the schedule, then there is no previous occurrence for the given from date.
				this._PreviousCache[v_ticks] = null; // Add the value to the cache.
				return null;
			}

			if (from == v_first_occurrence)
			{
				// If the from date is the first occurrence then the first occurrence is the previous date since this method is inclusive of the from date.
				this._PreviousCache[v_ticks] = v_first_occurrence; // Add the value to the cache.
				return v_first_occurrence;
			}

			// Variable used throughout the calculations.
			DateTime v_previous_occurrence = DateTime.MinValue;

			try
			{
				switch (this.RepeatType)
				{
					case ScheduleRepeatType.None:
						// The start date is the previous occurrence of this schedule.
						this._PreviousCache[v_ticks] = this.StartDate.Date; // Add the value to the cache.
						return this.StartDate.Date;

					case ScheduleRepeatType.Daily:
						v_previous_occurrence = this._CalculateNDay(from, true);
						break;

					case ScheduleRepeatType.Weekly:
						// Calculate the next occurrence backwards from the from date.
						v_previous_occurrence = this._CalculateNWeek(this._CalculateNextWeeklyOccurrence(from, true), true);
						break;

					case ScheduleRepeatType.Monthly:
						// Calculate the next occurrence and subtract a month if the next occurrence is not the from date.
						v_previous_occurrence = this._CalculateNextMonthlyOccurrence(from);
						if (v_previous_occurrence > from)
						{
							switch (this.MonthlyRepeatType)
							{
								default:
								case ScheduleMonthlyRepeatType.SpecificDayOfMonth:
									v_previous_occurrence = this._MonthlyEnsureLastDayOfMonth(v_previous_occurrence.AddMonths(-1));
									break;

								case ScheduleMonthlyRepeatType.SpecificNumberedDayOfWeek:
									v_previous_occurrence = this._MonthlyEnsureNthWeekDay(v_previous_occurrence.AddMonths(-1));
									break;
							}
						}

						v_previous_occurrence = this._CalculateNMonth(v_previous_occurrence, true);
						break;

					case ScheduleRepeatType.Yearly:
						// Calculate the next occurrence and subtract a year if the next occurrence is not the from date.
						v_previous_occurrence = this._CalculateNextYearlyOccurrence(from);
						if (v_previous_occurrence > from)
						{
							v_previous_occurrence = v_previous_occurrence.AddYears(-1);
						}

						v_previous_occurrence = this._CalculateNYear(v_previous_occurrence, true);
						break;
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				// The date calculations resulted in an invalid date, so we'll just assume there is no previous occurrence.
				this._PreviousCache[v_ticks] = null; // Add the value to the cache.
				return null;
			}

			// If the calculated date is before the date of the first occurrence, then this schedule has never occurred (or will never
			// occur) before the from date.
			if (v_previous_occurrence < v_first_occurrence)
			{
				// Technically, this should never happen, but we'll leave the check just in case.
				this._PreviousCache[v_ticks] = null; // Add the value to the cache.
				return null;
			}

			// If we are not in the process of calculating the last occurrence and the calculated date is after the last occurrence, then the
			// previous occurrence will be the last occurrence. We want to skip this if we are in the process of calculating the last occurrence
			// so that we don't end up with an infinite loop.
			if (!this._IsCalculatingLast)
			{
				DateTime? v_last = this.LastOccurrence();
				if (v_last != null && v_previous_occurrence > v_last.Value)
				{
					v_previous_occurrence = v_last.Value;
				}
			}

			v_previous_occurrence = v_previous_occurrence.Date; // We don't care about the time.
			this._PreviousCache[v_ticks] = v_previous_occurrence; // Add the value to the cache.
			return v_previous_occurrence;
		}

		/// <summary>Gets the last date that the schedule will occur (or has occurred).</summary>
		/// <returns>The last date that the schedule will occur (or has occurred), or <see langword="null"/> if there is no last occurrence for the schedule.</returns>
		/// <exception cref="InvalidOperationException">
		/// No start date has been specified.<br />
		/// - or -<br />
		/// <see cref="EndType"/> is <see cref="ScheduleEndType.AfterSpecificDate"/> and no end date has been specified.
		/// </exception>
		public DateTime? LastOccurrence()
		{
			// Method Dependencies:
			// - FirstOccurrence()
			// - PreviousOccurrence()
			// - _MonthlyEnsureLastDayOfMonth()
			// - _MonthlyEnsureNthWeekDay()
			// - _CalculateNDay() [From PreviousOccurrence()]
			// - _CalculateNWeek() [From PreviousOccurrence()]
			// - _CalculateNMonth() [From PreviousOccurrence()]
			// - _CalculateNextWeeklyOccurrence() [From FirstOccurrence() & PreviousOccurrence()]
			// - _CalculateNextMonthlyOccurrence() [From FirstOccurrence() & PreviousOccurrence()]
			// - _CalculateNextYearlyOccurrence() [From FirstOccurrence() & PreviousOccurrence()]

			// If the last occurrence has already been calculated then return the calculated value.
			if (!this.RecalculateLastOccurrence)
			{
				return this._LastOccurrence;
			}

			this._IsCalculatingLast = true;

			switch (this.EndType)
			{
				default:
				case ScheduleEndType.None:
					// If the schedule does not repeat, then the last occurrence is also the first occurrence, otherwise return null
					// to signal the caller that there is no end date for this schedule.
					if (this.RepeatType == ScheduleRepeatType.None)
					{
						this._LastOccurrence = this.FirstOccurrence();
					}
					else
					{
						this._LastOccurrence = null;
					}
					break;

				case ScheduleEndType.AfterSpecificNumberOfOccurrences:
					try
					{
						switch (this.RepeatType)
						{
							default:
							case ScheduleRepeatType.None:
								// If the schedule does not repeat, then the last occurrence is also the first occurrence.
								this._LastOccurrence = this.FirstOccurrence();
								break;

							case ScheduleRepeatType.Daily:
								// For daily repeat type, we can simply calculate the first occurrence, then add the number of days equal to:
								// ([total occurrences] - 1) * [repeat every N days value].
								this._LastOccurrence = this.FirstOccurrence().AddDays((this.EndNCount - 1) * this.NValue);
								break;

							case ScheduleRepeatType.Weekly:
								// Figure out how many times per week the schedule occurs.
								ulong[] v_week_days = this.WeeklyDays.ToArray();
								int v_week_day_count = v_week_days.Length;

								if (v_week_day_count <= 0)
								{
									// No weekdays have been specified, so the day of the week of the start date will be used, thus the number of
									// times per week the schedule occurs is once.
									v_week_day_count = 1;
								}

								// Get the first occurrence date of the schedule.
								DateTime v_first = this.FirstOccurrence();

								if (v_week_day_count == 1)
								{
									// If the schedule only occurs once per week, we can simply calculate the first occurrence, then add the number
									// of days equal to:
									// ([total occurrences] - 1) * [repeat every N weeks value] * 7.
									this._LastOccurrence = v_first.AddDays((this.EndNCount - 1) * this.NValue * 7);
									break;
								}

								// Otherwise we need to figure out how many weeks the schedule occurs for (not including the first NValue weeks), calculated by:
								// (ceiling([total occurrences] / [week day count]) * [repeat every N weeks value]) - [repeat every N weeks value]
								int v_num_weeks = ((int)Math.Ceiling((double)this.EndNCount / (double)v_week_day_count) * this.NValue) - this.NValue;

								// Now we can add that many weeks (minus one since the last week may not be a full week) to the first occurrence, plus the remainder number of days.
								int v_num_occurrances_in_last_week = this.EndNCount % v_week_day_count;

								// Calculate the last week of the schedule.
								DateTime v_last = v_first.AddDays(v_num_weeks * 7);

								if (v_num_occurrances_in_last_week == 0)
								{
									// The schedule occurs for every specified week day in the last week of the schedule, so we can simply calculate the last occurrence of the schedule in the last week.
									this._LastOccurrence = this._CalculateNextWeeklyOccurrence(v_last.LastWeekday(), true);
									break;
								}

								// Figure out the last week day occurrence the schedule occurs on in the last week and add that many days to the first day of the week of the last week of the schedule.
								Array.Sort(v_week_days); // make sure the week days are sorted chronologically

								// use the base-2 log of the value because the value is a flags enumerator, and so is a power of 2 where 1 = Sun, 2 = Mon, 4 = Tue, 8 = Wed, and so on
								this._LastOccurrence = v_last.FirstWeekday().AddDays(Math.Log((double)v_week_days[v_num_occurrances_in_last_week - 1], 2D));
								break;

							case ScheduleRepeatType.Monthly:
								// Get the month and year of the last occurrence by adding the number of months equal to:
								// ([total occurrences] - 1) * [repeat every N months value].
								DateTime v_date = this.FirstOccurrence().AddMonths((this.EndNCount - 1) * this.NValue);

								switch (this.MonthlyRepeatType)
								{
									default:
									case ScheduleMonthlyRepeatType.SpecificDayOfMonth:
										// Ensure that if the last day of the month is specified, then the date is the last day of the month.
										this._LastOccurrence = this._MonthlyEnsureLastDayOfMonth(v_date);
										break;

									case ScheduleMonthlyRepeatType.SpecificNumberedDayOfWeek:
										// Calculate the Nth weekday of the last occurrence's month and year.
										this._LastOccurrence = this._MonthlyEnsureNthWeekDay(v_date);
										break;
								}
								break;

							case ScheduleRepeatType.Yearly:
								// For yearly repeat type, we can simply calculate the first occurrence, then add a number of years equal to:
								// [total occurrences] - 1.
								this._LastOccurrence = this.FirstOccurrence().AddYears((this.EndNCount - 1) * this.NValue);

								// Special case for leap years
								if (this._LastOccurrence.Value.Month == 2 && this._LastOccurrence.Value.Day == 28 && this.DayOfMonth > 28 && this._LastOccurrence.Value.IsLeapYear(null))
								{
									this._LastOccurrence = this._LastOccurrence.Value.AddDays(1); // make the date Feb 29
								}
								break;
						} // switch
					}
					catch (ArgumentOutOfRangeException)
					{
						// The date calculations resulted in an invalid date, assume that there is no end date.
						this._LastOccurrence = null;
					}
					break;

				case ScheduleEndType.AfterSpecificDate:
					switch (this.RepeatType)
					{
						default:
						case ScheduleRepeatType.None:
							// If the schedule does not repeat, then the first occurrence is also the last occurrence.
							this._LastOccurrence = this.FirstOccurrence();
							break;

						case ScheduleRepeatType.Daily:
						case ScheduleRepeatType.Weekly:
						case ScheduleRepeatType.Monthly:
						case ScheduleRepeatType.Yearly:
							if (this.EndDate == null)
							{
								throw new InvalidOperationException("No end date has been specified.");
							}

							// We can simply calculate the previous occurrence on or before the end date.
							this._LastOccurrence = this.PreviousOccurrence(this.EndDate.Value);
							break;
					}
					break;
			} // switch

			if (this._LastOccurrence != null)
			{
				this._LastOccurrence = this._LastOccurrence.Value.Date; // We don't care about the time value.
			}

			this._IsCalculatingLast = false;
			this.RecalculateLastOccurrence = false;
			return this._LastOccurrence;
		}

		#region Private

		/// <summary>Internal method used to ensure that a date is an N-day value for daily repeat types.</summary>
		/// <param name="date">The date to check.</param>
		/// <param name="isPrevious">A value indicating if the previous occurrence is being calculated.</param>
		/// <returns>The date that falls on the next/previous N-value.</returns>
		private DateTime _CalculateNDay(DateTime date, bool isPrevious)
		{
			// Assumption: date parameter will never be before the first occurrence of the schedule.

			if (this.NValue == 1)
			{
				// No need to do calculations if the N-value is 1.
				return date;
			}

			long numDaysSinceStart = DateHelper.DateDiff(DatePart.DayOfYear, this.StartDate, date, null);
			long numDaysSinceStartRemainder = numDaysSinceStart % this.NValue;
			if (numDaysSinceStartRemainder == 0L)
			{
				// The date falls on one of the N days, so it is the correct occurrence date.
				return date;
			}

			return date.AddDays(isPrevious ? -numDaysSinceStartRemainder : this.NValue - numDaysSinceStartRemainder);
		}

		/// <summary>Internal method used to ensure that a date is an N-week value for weekly repeat types.</summary>
		/// <param name="date">The date to check.</param>
		/// <param name="isPrevious">A value indicating if the previous occurrence is being calculated.</param>
		/// <returns>The date that falls on the next/previous N-value.</returns>
		/// <exception cref="InvalidOperationException">No start date has been specified.</exception>
		private DateTime _CalculateNWeek(DateTime date, bool isPrevious)
		{
			// Assumption: date parameter will never be before the first occurrence of the schedule.

			if (this.NValue == 1)
			{
				// No need to do calculations if the N-value is 1.
				return date;
			}

			long numWeeksSinceStart = DateHelper.DateDiff(DatePart.WeekOfYear, this.FirstOccurrence(), date, null);
			long numWeeksSinceStartRemainder = numWeeksSinceStart % this.NValue;
			if (numWeeksSinceStartRemainder == 0L)
			{
				// The date falls on one of the N weeks, so it is the correct occurrence date.
				return date;
			}

			// Calculate the next/previous weekly occurrence from the beginning/ending of the week that falls on the calculated N-week.
			// For previous, we start at the end of the week and go towards the beginning of the week.
			// For next, we start at the beginning of the week and go towards the end of the week.
			return this._CalculateNextWeeklyOccurrence(isPrevious ? date.AddDays(-(numWeeksSinceStartRemainder * 7)).LastWeekday() : date.AddDays((this.NValue - numWeeksSinceStartRemainder) * 7).FirstWeekday(), isPrevious);
		}

		/// <summary>
		/// Internal method used by <see cref="FirstOccurrence"/> and <see cref="NextOccurrence(DateTime)"/> for calculating the next weekly
		/// occurrence of the schedule.
		/// </summary>
		/// <param name="from">The date the next occurrence date will be calculated from.</param>
		/// <param name="isPrevious">A value indicating if the previous occurrence is being calculated.</param>
		/// <returns>The next weekly occurrence of the schedule from the specified <paramref name="from"/> date.</returns>
		private DateTime _CalculateNextWeeklyOccurrence(DateTime from, bool isPrevious)
		{
			// If no days of the week have been specified, then use the day of the week of the start day.
			DaysOfWeek weekdays = this.WeeklyDays == DaysOfWeek.None ? this.StartDate.DayOfWeek.ConvertToDaysOfWeek() : this.WeeklyDays;

			// Loop until we find the next day of the week that the schedule occurs on. We don't need to loop more than 7 times, because if
			// the next date is not found after 7 iterations then something is seriously wrong.
			for (int i = 0; i <= 7; i++)
			{
				if (weekdays.ContainsDayOfWeek(from.DayOfWeek))
				{
					return from;
				}

				// Add/subtract a day and keep looping.
				from = from.AddDays(isPrevious ? -1 : 1);
			}

			// Something went seriously wrong and the next weekly occurrence can not be determined. Technically we should never get to this point,
			// however, we still want to do something to handle the situation should it ever arise.
			throw new InvalidOperationException("Can not determine the " + (isPrevious ? "previous" : "next") + " weekly occurrence.");
		}

		/// <summary>
		/// Internal method used by <see cref="FirstOccurrence"/> and <see cref="NextOccurrence(DateTime)"/> for calculating the next monthly
		/// occurrence of the schedule.
		/// </summary>
		/// <param name="from">The date the next occurrence date will be calculated from.</param>
		/// <returns>The next monthly occurrence of the schedule from the specified <paramref name="from"/> date.</returns>
		private DateTime _CalculateNextMonthlyOccurrence(DateTime from)
		{
			DateTime date;
			switch (this.MonthlyRepeatType)
			{
				default:
				case ScheduleMonthlyRepeatType.SpecificDayOfMonth:
					int daysInMonth = DateTime.DaysInMonth(from.Year, from.Month);
					date = new DateTime(from.Year, from.Month, this.DayOfMonth > daysInMonth ? daysInMonth : this.DayOfMonth);

					// If the calculated date is before the from date then we need to add a month.
					if (date < from)
					{
						// Add a month. .NET's date adding methods will make sure that when adding a month, it will not overflow to the next
						// month if the day of the month is a value greater than the number of days in the next month, so we don't have to worry
						// about making sure that is valid (i.e. adding 1 month to 1/31/2010 or 1/30/2010 will result in 2/28/2010, etc.).
						return this._MonthlyEnsureLastDayOfMonth(date.AddMonths(1));
					}
					return date;

				case ScheduleMonthlyRepeatType.SpecificNumberedDayOfWeek:
					// Calculate the Nth weekday of the from date's month and year.
					date = this._MonthlyEnsureNthWeekDay(from);

					// If the calculated date is before the from date, then add a month, and that is the next occurrence.
					return date < from ? this._MonthlyEnsureNthWeekDay(date.AddMonths(1)) : date;
			}
		}

		/// <summary>Internal method used to ensure that a date is an N-month value for the monthly repeat type.</summary>
		/// <param name="date">The date to check.</param>
		/// <param name="isPrevious">A value indicating if the previous occurrence is being calculated.</param>
		/// <returns>The date that falls on the next/previous N-month.</returns>
		/// <exception cref="InvalidOperationException">No start date has been specified.</exception>
		private DateTime _CalculateNMonth(DateTime date, bool isPrevious)
		{
			// Assumption: date parameter will never be before the first occurrence of the schedule.

			if (this.NValue == 1)
			{
				// No need to do calculations if the N-value is 1.
				return date;
			}

			int numMonthsSinceStart = (int)DateHelper.DateDiff(DatePart.Month, this.FirstOccurrence(), date, null);
			int numMonthsSinceStartRemainder = numMonthsSinceStart % this.NValue;
			if (numMonthsSinceStartRemainder == 0)
			{
				// The date falls on one of the N months, so it is the correct occurrence date.
				return date;
			}

			date = date.AddMonths(isPrevious ? -numMonthsSinceStartRemainder : this.NValue - numMonthsSinceStartRemainder);

			switch (this.MonthlyRepeatType)
			{
				default:
				case ScheduleMonthlyRepeatType.SpecificDayOfMonth:
					return this._MonthlyEnsureLastDayOfMonth(date);

				case ScheduleMonthlyRepeatType.SpecificNumberedDayOfWeek:
					return this._MonthlyEnsureNthWeekDay(date);
			}
		}

		/// <summary>
		/// Ensures that if the last day of the month is specified in <see cref="DayOfMonth"/>, then the specified <paramref name="date"/> is
		/// set to the last day of the month for the date it represents.
		/// </summary>
		/// <param name="date">The date to ensure the last day of the month for.</param>
		/// <returns>
		/// If <see cref="DayOfMonth"/> specifies the last day of the month, then a <see cref="DateTime"/> that represents the last day of the
		/// month for the date specified by <paramref name="date"/>, otherwise the value of <paramref name="date"/>.
		/// </returns>
		private DateTime _MonthlyEnsureLastDayOfMonth(DateTime date)
		{
			// Calculate the number of days in the month.
			int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

			// If it was specified to be the last day of the month, then make sure that the last day of the next month is specified.
			if (this.DayOfMonth > daysInMonth)
			{
				return new DateTime(date.Year, date.Month, daysInMonth);
			}
			return date;
		}

		/// <summary>Ensures that the specified date is an Nth weekday occurrence for the month.</summary>
		/// <param name="date">The date to check.</param>
		/// <returns>The Nth weekday occurrence for the month and year of the specified date.</returns>
		private DateTime _MonthlyEnsureNthWeekDay(DateTime date)
		{
			// Calculate the Nth weekday of the from date's month and year.
			DateTime? nthDay = DateHelper.NthDay(this.MonthlyNWeek, this.MonthlyDayOfWeek, date.Month, date.Year);

			// If the N-value didn't exist, then get the last occurrence of the weekday in the month.
			return nthDay == null || nthDay.Value == default(DateTime) ? DateHelper.LastNDay(this.MonthlyDayOfWeek, date.Month, date.Year) : nthDay.Value;
		}

		/// <summary>Internal method used to ensure that a date is an N-year value for yearly repeat types.</summary>
		/// <param name="date">The date to check.</param>
		/// <param name="isPrevious">A value indicating if the previous occurrence is being calculated.</param>
		/// <returns>The date that falls on the next/previous N-value.</returns>
		/// <exception cref="InvalidOperationException">No start date has been specified.</exception>
		private DateTime _CalculateNYear(DateTime date, bool isPrevious)
		{
			// Assumption: date parameter will never be before the first occurrence of the schedule.

			if (this.NValue == 1)
			{
				// No need to do calculations if the N-value is 1.
				return date;
			}

			int numYearsSinceStart = (int)DateHelper.DateDiff(DatePart.Year, this.FirstOccurrence(), date, null);
			int numYearsSinceStartRemainder = numYearsSinceStart % this.NValue;
			if (numYearsSinceStartRemainder == 0)
			{
				// The date falls on one of the N years, so it is the correct occurrence date.
				return date;
			}

			return date.AddYears(isPrevious ? -numYearsSinceStartRemainder : this.NValue - numYearsSinceStartRemainder);
		}

		/// <summary>
		/// Internal method used by <see cref="FirstOccurrence"/> and <see cref="NextOccurrence(DateTime)"/> for calculating the next yearly
		/// occurrence of the schedule.
		/// </summary>
		/// <param name="from">The date the next occurrence date will be calculated from.</param>
		/// <returns>The next yearly occurrence of the schedule from the specified <paramref name="from"/> date.</returns>
		private DateTime _CalculateNextYearlyOccurrence(DateTime from)
		{
			// Calculate the next occurrence
			int daysInMonth = DateTime.DaysInMonth(from.Year, this.YearlyMonth);
			DateTime date = new DateTime(from.Year, this.YearlyMonth, this.DayOfMonth > daysInMonth ? daysInMonth : this.DayOfMonth);

			// If the calculated date is before the from date then we need to add a year.
			if (date < from)
			{
				// If the last day of the month is specified and the month is February, then we need to re-calculate the last day of the month
				// since the last day of the month could have changed, otherwise we simply add a year.
				return this.YearlyMonth == 2 && this.DayOfMonth > 28
					? new DateTime(from.Year + 1, this.YearlyMonth, DateTime.DaysInMonth(from.Year + 1, this.YearlyMonth))
					: date.AddYears(1);
			}
			return date;
		}

		#endregion

		#endregion
	}

	/// <summary>Represents the repeat end type of a schedule, which determines how the end date of the schedule is calculated.</summary>
	public enum ScheduleEndType
	{
		/// <summary>No end date, the schedule repeats forever.</summary>
		None = 0,

		/// <summary>The schedule will repeat a specified number of times.</summary>
		AfterSpecificNumberOfOccurrences = 1,

		/// <summary>The schedule will end after a specific end date.</summary>
		AfterSpecificDate = 2
	}

	/// <summary>Represents the monthly repeat types available for a schedule.</summary>
	public enum ScheduleMonthlyRepeatType
	{
		/// <summary>The schedule will repeat on a specific day of every month.</summary>
		SpecificDayOfMonth = 0,

		/// <summary>The schedule will repeat on a specific day of a specified week every month (i.e. the 2nd Monday of every month).</summary>
		SpecificNumberedDayOfWeek = 1
	}

	/// <summary>Represents the repeat type of a schedule.</summary>
	public enum ScheduleRepeatType
	{
		/// <summary>The schedule does not repeat, and is a one time occurrence.</summary>
		None = 0,

		/// <summary>The schedule repeats on a daily occurrence.</summary>
		Daily = 1,

		/// <summary>The schedule repeats on a weekly occurrence.</summary>
		Weekly = 2,

		/// <summary>The schedule repeats on a monthly occurrence.</summary>
		Monthly = 3,

		/// <summary>The schedule repeats on a yearly occurrence.</summary>
		Yearly = 4
	}
}