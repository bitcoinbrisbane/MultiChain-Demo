using Newtonsoft.Json;
using System;

namespace Models.ListStreamsItems
{
    public class Result
    {
        [JsonProperty("key")]
        public String Key { get; set; }

        [JsonProperty("data")]
        public String Data { get; set; }

		[JsonProperty("confirmations")]
		public UInt64 Confirmations { get; set; }

        [JsonProperty("blocktime")]
        public UInt64 BlockTime { get; set; }
    }
}