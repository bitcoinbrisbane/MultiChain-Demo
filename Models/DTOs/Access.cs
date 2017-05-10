using System;
using System.Collections.Generic;

namespace Models.DTOs
{
    public class Access
    {
        public Guid PublishingEntityId { get; set; }

        public Guid ConsumingEntityId { get; set; }

        public Guid DataId { get; set; }

        public String PrivateKey { get; set; }
    }
}
