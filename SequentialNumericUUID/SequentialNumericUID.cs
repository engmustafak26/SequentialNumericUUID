using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialNumericUUID
{
    public static class SequentialNumericUID
    {
        const short CustomUniversalStartYear = 2023;
        const byte MicroPlusNanoDigitsLength = 4;
        private static DateTime CustomUniversalTime = new DateTime(CustomUniversalStartYear, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static ulong Generate()
        {
            DateTime current = DateTime.UtcNow;
            long timeStamp = (long)current.Subtract(CustomUniversalTime).TotalMilliseconds;
            return ulong.Parse($"{timeStamp.ToString()}{current.Microsecond.ToString("D3")}{(current.Nanosecond / 100).ToString()}");
        }

        public static DateTime GetUTCDateTime(ulong sequentialNumericUUID)
        {
            string customTimeStampString = sequentialNumericUUID.ToString();
            customTimeStampString = customTimeStampString.Substring(0, customTimeStampString.Length - MicroPlusNanoDigitsLength);
            return CustomUniversalTime.AddMilliseconds(ulong.Parse(customTimeStampString));
        }

        public static DateTime GetLocalDateTime(ulong sequentialNumericUUID)
        {
            return GetUTCDateTime(sequentialNumericUUID).ToLocalTime();
        }
    }
}
