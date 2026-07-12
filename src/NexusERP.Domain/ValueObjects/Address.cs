using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Domain.ValueObjects
{
    public sealed record Address(string Line1, string Line2, string City, string State, string Country, string ZipCode);
}
