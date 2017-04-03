using Newtonsoft.Json;
using System;

namespace Models.GetInfo
{
    public class Result
    {
        [JsonProperty("version")]
        public String Version { get; set; }

        [JsonProperty("balance")]
        public Decimal Balance { get; set; }
    }
}