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
        const byte RandomnessDigitsLength = 4;
        const byte ULongDigitsCount = 20;
        const ulong Seed = 169720846503714;
        const ulong RandomNanoSeed = 1697225263413546208;
        private static DateTime CustomUniversalTime = new DateTime(CustomUniversalStartYear, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static ulong Generate()
        {
            DateTime current = DateTime.UtcNow;
            long timeStamp = (long)current.Subtract(CustomUniversalTime).TotalMilliseconds;
            return ulong.Parse($"{timeStamp.ToString()}{current.Microsecond.ToString("D3")}{(current.Nanosecond / 100).ToString()}") - Seed;
        }

        public static ulong GenerateWithRandomnessInNanoSecondScope()
        {
            DateTime current = DateTime.UtcNow;
            long timeStamp = (long)current.Subtract(CustomUniversalTime).TotalMilliseconds;

            string ulongSegment = $"{timeStamp.ToString()}{current.Microsecond.ToString("D3")}{(current.Nanosecond / 100).ToString()}";
            string randomString = Random.Shared.Next(0, 9999).ToString();
            int recomendedRandomStringSliceLength = ULongDigitsCount - ulongSegment.Length;
            recomendedRandomStringSliceLength = recomendedRandomStringSliceLength > randomString.Length ?
                                                                                    randomString.Length : recomendedRandomStringSliceLength;

            return ulong.Parse($"{ulongSegment}{randomString.Substring(0, recomendedRandomStringSliceLength)
                                                            .PadLeft(5 - recomendedRandomStringSliceLength, '0')}") - RandomNanoSeed;
        }

        public static DateTime GetUTCDateTime(ulong sequentialNumericUUID, bool isGeneratedWithRandomness = false)
        {
            sequentialNumericUUID += isGeneratedWithRandomness ? RandomNanoSeed : Seed;
            string customTimeStampString = sequentialNumericUUID.ToString();
            customTimeStampString = customTimeStampString.Substring(0, customTimeStampString.Length
                                                            - (isGeneratedWithRandomness ? (RandomnessDigitsLength + MicroPlusNanoDigitsLength) : MicroPlusNanoDigitsLength));
            return CustomUniversalTime.AddMilliseconds(ulong.Parse(customTimeStampString));
        }

        public static DateTime GetLocalDateTime(ulong sequentialNumericUUID)
        {
            return GetUTCDateTime(sequentialNumericUUID).ToLocalTime();
        }
    }
}
