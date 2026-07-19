using Microsoft.EntityFrameworkCore;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Persistence.Contexts
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<User> Users => Set<User>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
