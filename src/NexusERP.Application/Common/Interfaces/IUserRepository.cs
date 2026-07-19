using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
        Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken);
        Task<bool> EmployeeHasUserAsync(Guid employeeId, CancellationToken cancellationToken);
    }
}
