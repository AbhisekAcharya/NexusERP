using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.Interfaces;
using NexusERP.Domain.Entities;
using NexusERP.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _context.Users.Include(u => u.Employee).FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
        }
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(x => x.Username == username, cancellationToken);
        }
        public async Task<bool> EmployeeHasUserAsync(Guid employeeId, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(x => x.EmployeeId == employeeId, cancellationToken);
        }
    }
}
