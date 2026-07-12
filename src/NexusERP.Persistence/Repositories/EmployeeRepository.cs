using NexusERP.Application.Interfaces;
using NexusERP.Domain.Entities;
using NexusERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Persistence.Repositories
{
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<Employee?> GetByEmployeeCodeAsync(string employeeCode, CancellationToken cancellationToken)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeCode == employeeCode, cancellationToken);
        }
        public async Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
        public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Employees.AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
