using Newtonsoft.Json;
using System;

namespace Models.ListStreams
{
    public class Request: Models.Request
    {
        [JsonProperty("chain_name")]
        public String ChainName { get; set; }

        [JsonProperty("params")]
        public object[] Params { get; set; }

        public Request()
        {
            Method = "liststreams";
        }
    }
}