using Newtonsoft.Json;

namespace WebDemo.Models.GetInfo
{
    public class Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}