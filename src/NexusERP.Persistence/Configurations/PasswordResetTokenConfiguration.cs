using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.Persistence.Configurations
{
    public sealed class PasswordResetTokenConfiguration : IEntityTypeConfiguration<PasswordResetToken>
    {
        public void Configure(EntityTypeBuilder<PasswordResetToken> builder)
        {
            builder.ToTable("PasswordResetTokens");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TokenHash).HasMaxLength(128).IsRequired();
            builder.HasIndex(x => x.TokenHash).IsUnique();
            builder.Property(x => x.ExpiresOnUtc).IsRequired();
            builder.Property(x => x.UsedOnUtc).IsRequired(false);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
