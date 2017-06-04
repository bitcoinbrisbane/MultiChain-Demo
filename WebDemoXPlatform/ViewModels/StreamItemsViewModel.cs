using System;
using System.Collections.Generic;

namespace WebDemoXPlatform.ViewModels
{
    public class StreamItemsViewModel
    {
        public String ChainName { get; set; }

        public String Stream { get; set; }

        public List<Models.ListStreamsItems.Result> Items { get; set; }

        public StreamItemsViewModel()
        {
            this.Items = new List<Models.ListStreamsItems.Result>();
        }
    }
}