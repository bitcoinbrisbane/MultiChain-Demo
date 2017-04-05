using System;
using System.ComponentModel.DataAnnotations;

namespace WebDemoXPlatform.ViewModels
{
    public class AddStreamViewModel
    {
        [Required]
        public String Chain { get; set; }

        /// <summary>
        /// Stream Name
        /// </summary>
        [Required]
        public String Name { get; set; }
    }
}