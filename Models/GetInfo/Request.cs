using Newtonsoft.Json;
using System;

namespace Models.GetInfo
{
    public class Request: WebDemo.Models.Request
    {
        [JsonProperty("chain_name")]
        public String ChainName { get; set; }

        [JsonProperty("params")]
        public object[] Params { get; set; }

        public Request()
        {
            Method = "getinfo";
        }
    }
}