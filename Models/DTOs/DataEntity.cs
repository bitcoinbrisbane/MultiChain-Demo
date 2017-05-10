using System;

namespace Models.DTOs
{
    public class DataEntity : BaseEntity
    {
        public String Data { get; set; }

        public DataEntity()
        {
            base.Id = Guid.NewGuid();
        }
    }
}
