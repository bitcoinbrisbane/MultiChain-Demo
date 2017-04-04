using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDemoXPlatform.ViewModels
{
    public class AddStreamKeyViewModel : AddStreamViewModel
    {
        [Required]
        String Key { get; set; }
    }
}