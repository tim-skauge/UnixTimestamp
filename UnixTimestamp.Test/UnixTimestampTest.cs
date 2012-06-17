using System;
using System.Globalization;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace mi7.Test
{
    public class UnixTimestampTest
    {
        [Theory, AutoData]
        public void ValueIsExpected(int expected)
        {
            var actual = new UnixTimestamp(expected);
            Assert.Equal(expected, actual.Value);
        }

        [Theory, AutoData]
        public void CanParseFromString(int expected)
        {
            UnixTimestamp actual;
            UnixTimestamp.TryParse(expected.ToString(CultureInfo.InvariantCulture), out actual);

            Assert.Equal(expected, actual);
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
            var expected = UnixTimestamp.Epoch.AddSeconds(sut.Value);
            Assert.Equal(expected, sut);
        }

        [Theory, AutoData]
        public void CanImplicitConvertToString(UnixTimestamp sut)
        {
            var expected = sut.Value.ToString(CultureInfo.InvariantCulture);
            Assert.Equal(expected, sut);
        }
    }
}
