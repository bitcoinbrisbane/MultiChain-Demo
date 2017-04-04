using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models.ListStreamsItems
{
    public class Response
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }
    }
}