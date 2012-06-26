using System;
using System.Globalization;

namespace mi7
{
    public struct UnixTimestamp
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public readonly long SecondsSinceEpoch;

        public UnixTimestamp(long secondsSinceEpoch)
        {
            SecondsSinceEpoch = secondsSinceEpoch;
        }

        public static bool TryParse(string value, out UnixTimestamp result)
        {
            result = new UnixTimestamp();

            int seconds;
            if (!int.TryParse(value, out seconds))
                return false;

            result = new UnixTimestamp(seconds);
            return true;
        }

        public static explicit operator UnixTimestamp(DateTime dateTime)
        {
            var secondsSinceEpoc = (long)(dateTime - Epoch).TotalSeconds;
            return new UnixTimestamp(secondsSinceEpoc);
        }

        public static implicit operator long(UnixTimestamp timestamp)
        {
            return timestamp.SecondsSinceEpoch;
        }

        public static implicit operator string(UnixTimestamp timestamp)
        {
            return timestamp.SecondsSinceEpoch.ToString(CultureInfo.InvariantCulture);
        }

        public static implicit operator DateTime(UnixTimestamp timestamp)
        {
            if (timestamp.SecondsSinceEpoch >= 253402300800)
                return DateTime.MaxValue;

            return Epoch.AddSeconds(timestamp.SecondsSinceEpoch);
        }
    }
}
