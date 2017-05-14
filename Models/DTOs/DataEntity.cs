using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class DataEntity : BaseEntity
    {
        [DisplayName("XML"), Required]
        public String Data { get; set; }

        public DataEntity()
        {
            base.Id = Guid.NewGuid();
        }
    }
}
