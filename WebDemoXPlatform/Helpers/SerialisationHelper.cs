using System;
using System.Collections.Generic;

namespace WebDemoXPlatform.Helpers
{
    public class SerialisationHelper
    {
        public static String ToHex(Models.DTOs.Instrument instrument)
        {
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(instrument);
            Byte[] bytes = System.Text.Encoding.ASCII.GetBytes(json);

            String hex = BitConverter.ToString(bytes);
            return hex.Replace("-", "");
        }
    }
}