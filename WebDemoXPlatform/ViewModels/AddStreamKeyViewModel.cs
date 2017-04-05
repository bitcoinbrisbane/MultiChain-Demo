using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDemoXPlatform.ViewModels
{
    public class AddStreamKeyViewModel : AddStreamViewModel
    {
        [Required]
        public String Key { get; set; }
    }
}