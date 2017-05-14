using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemoXPlatform.ViewModels
{
    public class DataEntityViewModel : Models.DTOs.DataEntity
    {
        public String PrivateKey { get; set; }

        public DataEntityViewModel()
        {
        }

        public DataEntityViewModel(Byte[] key)
        {
            this.PrivateKey = Convert.ToBase64String(key);
        }
    }
}