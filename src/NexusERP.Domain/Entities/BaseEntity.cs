using NexusERP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Domain.Entities
{
    public abstract class BaseEntity : IAuditable
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime CreatedOnUtc { get; protected set; } = DateTime.UtcNow;
        public DateTime? ModifiedOnUtc { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public void MarkAsDeleted()
        {
            IsDeleted = true;
            Touch();
        }
        protected void Touch()
        {
            ModifiedOnUtc = DateTime.UtcNow;
        }
    }
}
