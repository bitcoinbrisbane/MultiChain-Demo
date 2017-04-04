using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tests
{
    public class DTOTests
    {
        public void Should_Serialze_Instrument_DTO()
        {
            Models.DTOs.Instrument instrument = new DTOs.Instrument()
            {
                BICID = "123",
                Country = "AU",
                Name = "UBS Security",
                Market = "EQ"
            };


            
        }
    }
}
