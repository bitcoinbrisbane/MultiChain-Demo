using Newtonsoft.Json;
<<<<<<< HEAD:Models/ListStreams/Response.cs
using System;
using System.Collections.Generic;
=======
>>>>>>> fe1c36129f13a7e920e590435ea4a58015cd55b1:WebDemo/Models/GetInfo/Response.cs

namespace WebDemo.Models.ListStreams
{
    public class Response
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }
    }
}