using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Tools
{
    /// <summary>
    /// ʱ�䴦����
    /// </summary>
    public static class DateTimeHandler
    {
        #region Fields

        /// <summary>
        /// ÿ�����ȵ�һ���µ�����
        /// </summary>
        private readonly static int[] firstMonthOfSeason;

        #endregion

        #region Constructors

        /// <summary>
        /// ��̬���캯��
        /// </summary>
        static DateTimeHandler()
        {
            firstMonthOfSeason = new int[] { 1, 1, 1, 4, 4, 4, 7, 7, 7, 10, 10, 10 };
        }

        #endregion

        #region Methods

        /// <summary>
        /// ��ȡ��һ���ʱ��
        /// </summary>
        /// <param name="currentTime">��ǰʱ��</param>
        /// <returns>������һ���ʱ��</returns>
        public static DateTime GetNextSecond(DateTime currentTime)
        {
            DateTime nextSecond = currentTime.AddSeconds(1);
            DateTime result = new DateTime(nextSecond.Year, nextSecond.Month, nextSecond.Day, nextSecond.Hour,
                                           nextSecond.Minute, nextSecond.Second);
            return result;
        }

        /// <summary>
        /// ��ȡ��һ���ӵ�ʱ��
        /// </summary>
        /// <param name="currentTime">��ǰʱ��</param>
        /// <returns>������һ���ӵ�ʱ��</returns>
        public static DateTime GetNextMinute(DateTime currentTime)
        {
            DateTime nextMinute = currentTime.AddMinutes(1);
            DateTime result = new DateTime(nextMinute.Year, nextMinute.Month, nextMinute.Day, nextMinute.Hour,
                                           nextMinute.Minute, 0);
            return result;
        }

        /// <summary>
        /// ��ȡ��һСʱ��ʱ��
        /// </summary>
        /// <param name="currentTime">��ǰʱ��</param>
        /// <returns>������һСʱ��ʱ��</returns>
        public static DateTime GetNextHour(DateTime currentTime)
        {
            DateTime nextHour = currentTime.AddHours(1);
            DateTime result = new DateTime(nextHour.Year, nextHour.Month, nextHour.Day, nextHour.Hour, 0, 0);
            return result;
        }

        /// <summary>
        /// ��ȡ��һ������һ������
        /// </summary>
        /// <param name="currentTime">��ǰʱ��</param>
        /// <returns>������һ������һ������</returns>
        public static DateTime GetNextWeek(DateTime currentTime)
        {
            DateTime result = currentTime.Date;
            int dayOfWeek = (int)result.DayOfWeek;
            int dayDiff = dayOfWeek == 0 ? 1 : 8 - dayOfWeek;
            return result.AddDays(dayDiff);
        }

        /// <summary>
        /// ��ȡ��һ����һ�ŵ�����
        /// </summary>
        /// <param name="currentTime">��ǰʱ��</param>
        /// <returns>������һ����һ�ŵ�����</returns>
        public static DateTime GetNextMonth(DateTime currentTime)
        {
            DateTime nextMonth = currentTime.AddMonths(1);
            DateTime result = new DateTime(nextMonth.Year, nextMonth.Month, 1);
            return result;
        }

        /// <summary>
        /// ��ȡ��һ�����ȵ�һ�������
        /// </summary>
        /// <param name="currentTime">��ǰʱ��</param>
        /// <returns>������һ�����ȵ�һ�������</returns>
        public static DateTime GetNextSeason(DateTime currentTime)
        {
            DateTime nextSeason = currentTime.AddMonths(3);
            int month = firstMonthOfSeason[nextSeason.Month];
            return new DateTime(nextSeason.Year, month, 1);
        }

        /// <summary>
        /// ��ȡ�����һ�������
        /// </summary>
        /// <param name="currentTime">��ǰʱ��</param>
        /// <returns>���������һ�������</returns>
        public static DateTime GetNextYear(DateTime currentTime)
        {
            DateTime result = new DateTime(currentTime.Year + 1, 1, 1);
            return result;
        }

        #endregion
    }
}
