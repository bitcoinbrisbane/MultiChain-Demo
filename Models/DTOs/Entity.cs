using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class Entity : BaseEntity
    {
        [RegularExpression("AZ09[4-11]")]
        public String BIC { get; set; }

        public String Name { get; set; }

        public String Country { get; set; }

        [MaxLength(4)]
        public String Market { get; set; }

        [MaxLength(10)]
        public String InstrumentType { get; set; }

        public String PublicKey { get; set; }

        public Entity()
        {
            base.Id = Guid.NewGuid();
        }
    }
}
