using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Tools
{
    /// <summary>
    /// Datetime handler
    /// </summary>
    public static class DateTimeHandler
    {
        #region Fields

        /// <summary>
        /// the first month number of seasons
        /// </summary>
        private readonly static int[] firstMonthOfSeason;

        #endregion

        #region Constructors

        /// <summary>
        /// static constructor
        /// </summary>
        static DateTimeHandler()
        {
            firstMonthOfSeason = new int[] { 1, 1, 1, 4, 4, 4, 7, 7, 7, 10, 10, 10 };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the datetime of next second
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next second</returns>
        public static DateTime GetNextSecond(DateTime currentTime)
        {
            DateTime nextSecond = currentTime.AddSeconds(1);
            DateTime result = new DateTime(nextSecond.Year, nextSecond.Month, nextSecond.Day, nextSecond.Hour,
                                           nextSecond.Minute, nextSecond.Second);
            return result;
        }

        /// <summary>
        /// Get the datetime of next minute
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next minute</returns>
        public static DateTime GetNextMinute(DateTime currentTime)
        {
            DateTime nextMinute = currentTime.AddMinutes(1);
            DateTime result = new DateTime(nextMinute.Year, nextMinute.Month, nextMinute.Day, nextMinute.Hour,
                                           nextMinute.Minute, 0);
            return result;
        }

        /// <summary>
        /// Get the datetime of next hour
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next hour</returns>
        public static DateTime GetNextHour(DateTime currentTime)
        {
            DateTime nextHour = currentTime.AddHours(1);
            DateTime result = new DateTime(nextHour.Year, nextHour.Month, nextHour.Day, nextHour.Hour, 0, 0);
            return result;
        }

        /// <summary>
        /// Get the datetime of next day
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next day</returns>
        public static DateTime GetNextDay(DateTime currentTime)
        {
            DateTime nextHour = currentTime.AddDays(1);
            DateTime result = new DateTime(nextHour.Year, nextHour.Month, nextHour.Day);
            return result;
        }

        /// <summary>
        /// Get the datetime of next week
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next week</returns>
        public static DateTime GetNextWeek(DateTime currentTime)
        {
            DateTime result = currentTime.Date;
            int dayOfWeek = (int)result.DayOfWeek;
            int dayDiff = dayOfWeek == 0 ? 1 : 8 - dayOfWeek;
            return result.AddDays(dayDiff);
        }

        /// <summary>
        /// Get the datetime of next month
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next month</returns>
        public static DateTime GetNextMonth(DateTime currentTime)
        {
            DateTime nextMonth = currentTime.AddMonths(1);
            DateTime result = new DateTime(nextMonth.Year, nextMonth.Month, 1);
            return result;
        }

        /// <summary>
        /// Get the datetime of next season
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next season</returns>
        public static DateTime GetNextSeason(DateTime currentTime)
        {
            DateTime nextSeason = currentTime.AddMonths(3);
            int month = firstMonthOfSeason[nextSeason.Month];
            return new DateTime(nextSeason.Year, month, 1);
        }

        /// <summary>
        /// Get the datetime of next year
        /// </summary>
        /// <param name="currentTime">current datetime</param>
        /// <returns>Get the datetime of next year</returns>
        public static DateTime GetNextYear(DateTime currentTime)
        {
            DateTime result = new DateTime(currentTime.Year + 1, 1, 1);
            return result;
        }

        #endregion
    }
}
