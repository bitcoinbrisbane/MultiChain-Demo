using System;
using System.Collections.Generic;
using System.Linq;

namespace WebDemoXPlatform.Helpers
{
    public static class SerialisationHelper
    {
        public static String ToHex(Models.DTOs.Instrument instrument)
        {
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(instrument);
            Byte[] bytes = System.Text.Encoding.ASCII.GetBytes(json);

            String hex = BitConverter.ToString(bytes);
            return hex.Replace("-", "");
        }

        public static T ToObject<T>(String value)
        {
            Byte[] bytes = Enumerable.Range(0, value.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(value.Substring(x, 2), 16))
                     .ToArray();

            T dto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(System.Text.Encoding.ASCII.GetString(bytes));
            return dto;
        }
    }
}