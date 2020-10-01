using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Extensions;

namespace Washi.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Laundry> Laundries { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(50);
       /*     builder.Entity<User>().HasData
                (
                    new User { Id = 100, Email = "felipedota2@gmail.com", Password = "slark" },
                    new User { Id = 101, Email = "xavistian@gmail.com", Password = "tiaaaaaaaan" }
                );          */
            //Account Entity
            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>()
                .HasDiscriminator(p => p.AccountType)
                .HasValue<Customer>("Customer")
                .HasValue<Laundry>("Laundry");
            builder.Entity<Account>().HasKey(p => p.UserId);
            builder.Entity<Account>().Property(p => p.UserId);
            builder.Entity<Account>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Account>().Property(p => p.LastName).IsRequired();
            builder.Entity<Account>().Property(p => p.AccountType).IsRequired();
            builder.Entity<Account>().Property(p => p.Address).IsRequired();
            builder.Entity<Account>().Property(p => p.PhoneNumber).IsRequired();
            builder.Entity<Account>().Property(p => p.DateOfRegistry).IsRequired();

            //Customer Entity
            builder.Entity<Customer>().Property(p => p.DateOfBirth).IsRequired();
            builder.Entity<Customer>().Property(p => p.Sex).IsRequired(false);

            //Laundry Entity
            builder.Entity<Laundry>().Property(p => p.CorporationName).IsRequired(false);

            ApplySnakeCaseNamingConvention(builder);
        }

        private void ApplySnakeCaseNamingConvention(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }

    }
}
