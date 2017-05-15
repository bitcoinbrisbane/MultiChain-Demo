using Newtonsoft.Json;
using System;

namespace Models.PublishStreamItem
{
    public class Request: Models.Request
    {
        [JsonProperty("chain_name")]
        public String ChainName { get; set; }

        [JsonProperty("params")]
        public object[] Params { get; set; }

        public Request(String chain, String stream)
        {
            //publish chain name
            Method = String.Format("publish");
        }
    }
}