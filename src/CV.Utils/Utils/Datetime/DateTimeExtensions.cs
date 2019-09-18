using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Utils.Utils.Datetime
{
    public static class DateTimeExtensions
    {
        public static long ToTimestamp(this DateTime dateTime)
        {
            return DateTimeHelper.GetTimestamp(dateTime);
        }

        public static long ToTimestamp(this DateTimeOffset dateTimeOffset)
        {
            return DateTimeHelper.GetTimestamp(dateTimeOffset);
        }

        public static DateTime TruncateTo(this DateTime dateTime, TruncateToType truncateTo)
        {
            return DateTimeHelper.TruncateTo(dateTime, truncateTo);
        }

        public static DateTimeOffset TruncateTo(this DateTimeOffset dateTimeOffset, TruncateToType truncateTo)
        {
            return DateTimeHelper.TruncateTo(dateTimeOffset, truncateTo);
        }

        /// <param name="dateTime">  </param>
        /// <param name="timeZoneId"> Time Zone ID, See more: https://msdn.microsoft.com/en-us/library/gg154758.aspx </param>
        public static DateTimeOffset WithTimeZone(this DateTime dateTime, string timeZoneId)
        {
            return DateTimeHelper.WithTimeZone(dateTime, timeZoneId);
        }

        public static DateTimeOffset WithTimeZone(this DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            return DateTimeHelper.WithTimeZone(dateTime, timeZoneInfo);
        }

        public static DateTimeOffset ConvertTimeZone(this DateTimeOffset dateTime, string timeZoneId)
        {
            return DateTimeHelper.ConvertTimeZone(dateTime, timeZoneId);
        }
    }
}
