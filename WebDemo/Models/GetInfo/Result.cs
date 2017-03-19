using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models.GetInfo
{
    public class Result
    {
        [JsonProperty("version")]
        public String Version { get; set; }

        [JsonProperty("balance")]
        public Decimal Balance { get; set; }
    }
}