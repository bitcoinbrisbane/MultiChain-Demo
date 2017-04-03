using Newtonsoft.Json;
using System;

namespace WebDemo.Models.ListStreams
{
    public class Result
    {
        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("startblock")]
        public UInt64 StartBlock { get; set; }

        [JsonProperty("endblock")]
        public UInt64 EndBlock { get; set; }
    }
}