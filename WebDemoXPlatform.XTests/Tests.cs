using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebDemoXPlatform.XTests
{
    public class Tests
    {
        [Fact]
        public void Should_Ser_DTO()
        {
            Models.DTOs.Instrument instrument = new Models.DTOs.Instrument()
            {
                BICID = "1",
                Country = "AU",
                Market = "Equity",
                Name = "UBS"
            };

            String actual = WebDemoXPlatform.Helpers.SerialisationHelper.ToHex(instrument);
            const string expected = "7B224249434944223A2231222C224E616D65223A22554253222C22436F756E747279223A224155222C224D61726B6574223A22457175697479227D";

            Assert.Equal(expected, actual);
        }
    }
}
