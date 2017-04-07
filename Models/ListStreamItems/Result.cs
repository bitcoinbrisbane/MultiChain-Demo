using Newtonsoft.Json;
using System;

namespace Models.ListStreamsItems
{
    public class Result
    {
        [JsonProperty("publishers")]
        public String[] Publishers { get; set; }

        [JsonProperty("key")]
        public String Key { get; set; }

        [JsonProperty("data")]
        public String Data { get; set; }

        [JsonProperty("txid")]
        public String TxId { get; set; }

        [JsonProperty("confirmations")]
		public UInt64 Confirmations { get; set; }

        [JsonProperty("blocktime")]
        public UInt64 BlockTime { get; set; }
    }
}