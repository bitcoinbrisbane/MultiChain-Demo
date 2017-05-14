using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemoXPlatform.ViewModels
{
    public class DataEntityViewModel : Models.DTOs.DataEntity
    {
        [DisplayName("256 bit private key as base64"), Required, RegularExpression("^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$")]
        //^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$
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