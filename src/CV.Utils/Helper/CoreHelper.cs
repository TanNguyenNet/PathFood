using CV.Utils.Contants;
using CV.Utils.Utils.Datetime;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Utils.Helper
{
    public class CoreHelper
    {
        public static DateTimeOffset SystemTimeNowUTC
        {
            get
            {
                return DateTimeOffset.UtcNow;
            }
        }
        public static DateTimeOffset SystemTimeNowUTCTimeZoneLocal
        {
            get
            {
                return SystemTimeNowUTC.ConvertTimeZone(Formattings.TimeZone);
            }
        }

        public static DateTimeOffset ConvertToUTCTimeZoneLocal(DateTimeOffset dateTime)
        {
            return dateTime.ConvertTimeZone(Formattings.TimeZone);
        }
        public static string GeneratorGuid
        {
            get
            {
                return Guid.NewGuid().ToString("N");
            }
        }
    }
}
