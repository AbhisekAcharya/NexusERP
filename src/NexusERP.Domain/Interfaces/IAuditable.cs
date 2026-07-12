using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Domain.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedOnUtc { get; }
        DateTime? ModifiedOnUtc { get; }
    }
}
