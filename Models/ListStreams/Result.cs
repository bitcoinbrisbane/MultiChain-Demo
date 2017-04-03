using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models.ListStreams
{
    public class Result
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("open")]
        public Boolean Open { get; set; }

		[JsonProperty("subscribed")]
		public Boolean Subscribed { get; set; }
    }
}