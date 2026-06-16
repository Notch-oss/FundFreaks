using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserAuthenticationService.Models
{
    public partial class FundFreaksUsersContext : DbContext
    {
        public FundFreaksUsersContext()
        {
        }

        public FundFreaksUsersContext(DbContextOptions<FundFreaksUsersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegisterUser> RegisterUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuration is handled in Program.cs through dependency injection
            // This method is kept for backward compatibility but should not be used
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConfirmPassword).HasColumnName("confirmPassword");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
