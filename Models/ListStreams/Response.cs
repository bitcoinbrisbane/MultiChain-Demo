﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models.ListStreams
{
    public class Response
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }
    }
}