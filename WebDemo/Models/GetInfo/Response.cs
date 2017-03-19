using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models.GetInfo
{
    public class Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}