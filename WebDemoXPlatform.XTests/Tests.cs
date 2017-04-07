using System;
using Xunit;

namespace WebDemoXPlatform.XTests
{
    public class Tests
    {
        [Fact]
        public void Should_Serialize_DTO()
        {
            Models.DTOs.Instrument instrument = new Models.DTOs.Instrument()
            {
                BICID = "1",
                Country = "AU",
                Market = "Equity",
                Name = "UBS"
            };

            String actual = Helpers.SerialisationHelper.ToHex(instrument);
            const string expected = "7B224249434944223A2231222C224E616D65223A22554253222C22436F756E747279223A224155222C224D61726B6574223A22457175697479227D";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_DeSerialize_DTO()
        {
            Models.DTOs.Instrument expected = new Models.DTOs.Instrument()
            {
                BICID = "1",
                Country = "AU",
                Market = "Equity",
                Name = "UBS"
            };

            Models.DTOs.Instrument actual = Helpers.SerialisationHelper.ToObject<Models.DTOs.Instrument>("7B224249434944223A2231222C224E616D65223A22554253222C22436F756E747279223A224155222C224D61726B6574223A22457175697479227D");
            Assert.Equal(expected.BICID, actual.BICID);
            Assert.Equal(expected.Country, actual.Country);
            Assert.Equal(expected.Market, actual.Market);
            Assert.Equal(expected.Name, actual.Name);
        }
    }
}
