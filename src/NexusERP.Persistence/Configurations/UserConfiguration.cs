using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Persistence.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.Role).HasConversion<int>().IsRequired();
            builder.HasOne(x => x.Employee).WithOne().HasForeignKey<User>(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
