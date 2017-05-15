using Newtonsoft.Json;
using System;

namespace Models.PublishStreamItem
{
    public class Request: Models.Request
    {
        [JsonProperty("params")]
        public object[] Params { get; set; }

        public Request(String chain, String stream)
        {
            //publish chain name
            Method = String.Format("publish {0}", chain);
        }
    }
}