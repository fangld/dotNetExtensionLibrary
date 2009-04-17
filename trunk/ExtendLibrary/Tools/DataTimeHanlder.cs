using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Tools
{
    /// <summary>
    /// 时间处理器
    /// </summary>
    public static class DateTimeHandler
    {
        #region Fields

        /// <summary>
        /// 每个季度第一个月的数字
        /// </summary>
        private readonly static int[] firstMonthOfSeason;

        #endregion

        #region Constructors

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static DateTimeHandler()
        {
            firstMonthOfSeason = new int[] { 1, 1, 1, 4, 4, 4, 7, 7, 7, 10, 10, 10 };
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取下一秒的时间
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>返回下一秒的时间</returns>
        public static DateTime GetNextSecond(DateTime currentTime)
        {
            DateTime nextSecond = currentTime.AddSeconds(1);
            DateTime result = new DateTime(nextSecond.Year, nextSecond.Month, nextSecond.Day, nextSecond.Hour,
                                           nextSecond.Minute, nextSecond.Second);
            return result;
        }

        /// <summary>
        /// 获取下一分钟的时间
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>返回下一分钟的时间</returns>
        public static DateTime GetNextMinute(DateTime currentTime)
        {
            DateTime nextMinute = currentTime.AddMinutes(1);
            DateTime result = new DateTime(nextMinute.Year, nextMinute.Month, nextMinute.Day, nextMinute.Hour,
                                           nextMinute.Minute, 0);
            return result;
        }

        /// <summary>
        /// 获取下一小时的时间
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>返回下一小时的时间</returns>
        public static DateTime GetNextHour(DateTime currentTime)
        {
            DateTime nextHour = currentTime.AddHours(1);
            DateTime result = new DateTime(nextHour.Year, nextHour.Month, nextHour.Day, nextHour.Hour, 0, 0);
            return result;
        }

        /// <summary>
        /// 获取下一个星期一的日期
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>返回下一个星期一的日期</returns>
        public static DateTime GetNextWeek(DateTime currentTime)
        {
            DateTime result = currentTime.Date;
            int dayOfWeek = (int)result.DayOfWeek;
            int dayDiff = dayOfWeek == 0 ? 1 : 8 - dayOfWeek;
            return result.AddDays(dayDiff);
        }

        /// <summary>
        /// 获取下一个月一号的日期
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>返回下一个月一号的日期</returns>
        public static DateTime GetNextMonth(DateTime currentTime)
        {
            DateTime nextMonth = currentTime.AddMonths(1);
            DateTime result = new DateTime(nextMonth.Year, nextMonth.Month, 1);
            return result;
        }

        /// <summary>
        /// 获取下一个季度第一天的日期
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>返回下一个季度第一天的日期</returns>
        public static DateTime GetNextSeason(DateTime currentTime)
        {
            DateTime nextSeason = currentTime.AddMonths(3);
            int month = firstMonthOfSeason[nextSeason.Month];
            return new DateTime(nextSeason.Year, month, 1);
        }

        /// <summary>
        /// 获取下年第一天的日期
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns>返回下年第一天的日期</returns>
        public static DateTime GetNextYear(DateTime currentTime)
        {
            DateTime result = new DateTime(currentTime.Year + 1, 1, 1);
            return result;
        }

        #endregion
    }
}
