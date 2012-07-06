using System;
using System.Globalization;

namespace MI7
{
    public struct UnixTimestamp
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private readonly long secondsSinceEpoch;

        public UnixTimestamp(long secondsSinceEpoch)
        {
            this.secondsSinceEpoch = secondsSinceEpoch;
        }

        public long SecondsSinceEpoch
        {
            get { return secondsSinceEpoch; }
        }

        public static bool TryParse(string value, out UnixTimestamp result)
        {
            result = new UnixTimestamp();

            long seconds;
            if (!long.TryParse(value, out seconds))
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
            return timestamp.secondsSinceEpoch;
        }

        public static implicit operator string(UnixTimestamp timestamp)
        {
            return timestamp.secondsSinceEpoch.ToString(CultureInfo.InvariantCulture);
        }

        public static implicit operator DateTime(UnixTimestamp timestamp)
        {
            if (timestamp.secondsSinceEpoch >= 253402300800)
                return DateTime.MaxValue;

            return Epoch.AddSeconds(timestamp.secondsSinceEpoch);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(UnixTimestamp other)
        {
            return other.secondsSinceEpoch == secondsSinceEpoch;
        }

        public override int GetHashCode()
        {
            return secondsSinceEpoch.GetHashCode();
        }
    }
}
