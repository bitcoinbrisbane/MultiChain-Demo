using Newtonsoft.Json;
using System;

namespace Models
{
    public class Response
    {
        [JsonProperty("jsonrpc")]
        public String Jsonrpc { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }
    }
}
