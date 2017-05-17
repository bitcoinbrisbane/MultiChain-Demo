using System;
using System.Collections.Generic;

namespace WebDemoXPlatform.ViewModels
{
    public class StreamItemsViewModel : List<Models.ListStreamsItems.Result>
    {
        public String Chain { get; set; }

        public String Stream { get; set; }
    }
}