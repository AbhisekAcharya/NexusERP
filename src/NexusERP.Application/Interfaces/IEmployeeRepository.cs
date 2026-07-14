using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Employee?> GetByEmployeeCodeAsync(string employeeCode, CancellationToken cancellationToken);
        Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(Employee employee, CancellationToken cancellationToken);
        Task DeleteAsync(Employee employee, CancellationToken cancellationToken);
        Task<bool> ExistsByEmployeeCodeAsync(string employeeCode, Guid excludeEmployeeId, CancellationToken cancellationToken);
        Task<bool> ExistsByEmailAsync(string email, Guid excludeEmployeeId, CancellationToken cancellationToken);
    }
}
