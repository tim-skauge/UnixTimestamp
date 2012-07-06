using System;
using System.Globalization;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace MI7.Test
{
    public class UnixTimestampTest
    {
        [Theory, AutoData]
        public void SecondsSinceEpochIsExpected(long expected)
        {
            var actual = new UnixTimestamp(expected);
            Assert.Equal(expected, actual.SecondsSinceEpoch);
        }

        [Theory, AutoData]
        public void CanParseFromString(long expected)
        {
            UnixTimestamp actual;
            UnixTimestamp.TryParse(expected.ToString(CultureInfo.InvariantCulture), out actual);

            Assert.Equal(expected, actual.SecondsSinceEpoch);
        }

        [Fact]
        public void CanParseReturnsExpectedIfUnableToParse()
        {
            UnixTimestamp _;
            Assert.False(UnixTimestamp.TryParse("InvalidUnixTimestamp", out _));
        }

        [Fact]
        public void EpocIsExpected()
        {
            var expected = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var actual = UnixTimestamp.Epoch;

            Assert.Equal(expected, actual);
        }

        [Theory, AutoData]
        public void CanImplicitConvertToDateTime(UnixTimestamp sut)
        {
            var expected = UnixTimestamp.Epoch.AddSeconds(sut.SecondsSinceEpoch);
            Assert.Equal(expected, sut);
        }

        [Theory, AutoData]
        public void CanImplicitConvertToString(UnixTimestamp sut)
        {
            var expected = sut.SecondsSinceEpoch.ToString(CultureInfo.InvariantCulture);
            Assert.Equal(expected, sut);
        }

        [Fact]
        public void CanParseDateTimeMaxValue()
        {
            var sut = (UnixTimestamp)DateTime.MaxValue;
            Assert.Equal(DateTime.MaxValue, sut);
        }

        [Fact]
        public void CanParseDateTimeMinValue()
        {
            var sut = (UnixTimestamp)DateTime.MinValue;
            Assert.Equal(DateTime.MinValue, sut);
        }

        [Fact]
        public void EqualsReturnsExpected()
        {
            Assert.Equal(new UnixTimestamp(1000), new UnixTimestamp(1000));
        }
    }
}
