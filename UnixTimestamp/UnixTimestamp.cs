using System;
using System.Globalization;

namespace mi7
{
    public struct UnixTimestamp
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public readonly int SecondsSinceEpoch;

        public UnixTimestamp(int secondsSinceEpoch)
        {
            SecondsSinceEpoch = secondsSinceEpoch;
        }

        public static bool TryParse(string value, out UnixTimestamp result)
        {
            result = new UnixTimestamp();

            int secondsSinceEpoch;
            if (!int.TryParse(value, out secondsSinceEpoch))
                return false;

            result = new UnixTimestamp(secondsSinceEpoch);
            return true;
        }

        public static explicit operator UnixTimestamp(DateTime dateTime)
        {
            var secondsSinceEpoc = (int)(dateTime - Epoch).TotalSeconds;
            return new UnixTimestamp(secondsSinceEpoc);
        }

        public static implicit operator int(UnixTimestamp timestamp)
        {
            return timestamp.SecondsSinceEpoch;
        }

        public static implicit operator string(UnixTimestamp timestamp)
        {
            return timestamp.SecondsSinceEpoch.ToString(CultureInfo.InvariantCulture);
        }

        public static implicit operator DateTime(UnixTimestamp timestamp)
        {
            return Epoch.AddSeconds(timestamp.SecondsSinceEpoch);
        }
    }
}
