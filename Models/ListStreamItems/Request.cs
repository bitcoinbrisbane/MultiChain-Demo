using Newtonsoft.Json;
using System;

namespace Models.ListStreamsItems
{
    public class Request: Models.Request
    {
        [JsonProperty("chain_name")]
        public String ChainName { get; set; }

        [JsonProperty("stream")]
        public String Stream { get; set; }

        [JsonProperty("params")]
        public object[] Params { get; set; }

        public Request()
        {
            Method = "liststreamitems";
        }
    }
}