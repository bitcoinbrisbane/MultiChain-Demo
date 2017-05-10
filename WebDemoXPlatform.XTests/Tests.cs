using System;
using Xunit;

namespace WebDemoXPlatform.XTests
{
    public class Tests
    {
        [Fact]
        public void Should_Serialize_DTO()
        {
            Models.DTOs.Entity instrument = new Models.DTOs.Entity()
            {
                BIC = "1",
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
            Models.DTOs.Entity expected = new Models.DTOs.Entity()
            {
                BIC = "1",
                Country = "AU",
                Market = "Equity",
                Name = "UBS"
            };

            Models.DTOs.Entity actual = Helpers.SerialisationHelper.ToObject<Models.DTOs.Entity>("7B224249434944223A2231222C224E616D65223A22554253222C22436F756E747279223A224155222C224D61726B6574223A22457175697479227D");
            Assert.Equal(expected.BIC, actual.BIC);
            Assert.Equal(expected.Country, actual.Country);
            Assert.Equal(expected.Market, actual.Market);
            Assert.Equal(expected.Name, actual.Name);
        }
    }
}
