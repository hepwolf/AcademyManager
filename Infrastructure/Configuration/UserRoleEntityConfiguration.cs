﻿using AcademyManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyManager.Infrastructure.Configuration
{
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {

            // key 
            builder.HasKey(ur => new {ur.UserId, ur.RoleId });

            // Navigation Between UserRole & UserAccunt
            builder.HasOne(ur => ur.UserAccunt)
               .WithMany(u => u.UserRoles)
               .HasForeignKey(ur => ur.UserId);

            // Navigation Between UserRole & Role
            builder.HasOne(ur => ur.Role)
               .WithMany(r => r.UserRoles)
               .HasForeignKey(ur => ur.RoleId);
        }
    }
}
