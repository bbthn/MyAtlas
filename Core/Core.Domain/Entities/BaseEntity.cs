﻿

using Core.Domain.Interfaces;

namespace Core.Domain.Entities
{
    public class BaseEntity: IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
