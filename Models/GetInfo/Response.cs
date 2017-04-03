using Newtonsoft.Json;
using System;

namespace Models.GetInfo
{
    public class Response
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }
    }
}