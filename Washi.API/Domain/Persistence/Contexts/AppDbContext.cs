using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Extensions;

namespace Washi.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>()
                .HasOne(p => p.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(50);
           
            builder.Entity<User>().HasData
                (
                    new User { Id = 1, Email = "felipedota2@gmail.com", Password = "slark" },
                    new User { Id = 2, Email = "xavistian@gmail.com", Password = "tiaaaaaaaan" }
                );

            //UserProfile Entity

            builder.Entity<UserProfile>().ToTable("UserProfiles");
            builder.Entity<UserProfile>().HasKey(p => p.Id);
            builder.Entity<UserProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserProfile>().Property(p => p.UserId);
            builder.Entity<UserProfile>().Property(p => p.FirstName);
            builder.Entity<UserProfile>().Property(p => p.LastName);
            builder.Entity<UserProfile>().Property(p => p.DateOfBirth);
            builder.Entity<UserProfile>().Property(p => p.Sex);
            builder.Entity<UserProfile>().Property(p => p.DateOfRegistry);
            builder.Entity<UserProfile>().Property(p => p.Address).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.PhoneNumber).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.CorporationName);
            builder.Entity<UserProfile>().Property(p => p.UserType).IsRequired();

            builder.Entity<UserProfile>().HasData
                (
                    new UserProfile { Id = 1, UserId = 1, FirstName = "Felipe", LastName = "Kacomt", Sex = ESex.Female, Address = "Chiclayo", PhoneNumber = 987654321, UserType = EUserType.Washer },
                    new UserProfile { Id = 2, UserId = 2, CorporationName = "Xavistian Inc", Address = "Watchflowers", PhoneNumber = 999888777, UserType = EUserType.Laundry }
                );
            // PaymentMethod Entity
            builder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            builder.Entity<PaymentMethod>().HasKey(p => p.Id);
            builder.Entity<PaymentMethod>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentMethod>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<PaymentMethod>().HasData
                (
                    new PaymentMethod { Id = 67, Name = "TarjetaDeRegalo"},
                    new PaymentMethod { Id = 68, Name = "TarjetaConeyPark" }
                );

            // Service Entity
            builder.Entity<Service>().ToTable("Service");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Service>().HasData
                (
                    new Service { Id = 100, Name = "LavadoalSeco" },
                    new Service { Id = 101, Name = "Planchado" }
                );

            //Material Entity
            builder.Entity<Material>().ToTable("Material");
            builder.Entity<Material>().HasKey(p => p.Id);
            builder.Entity<Material>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Material>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Material>().HasData
                (
                    new Material { Id = 100, Name = "Plancha"},
                    new Material { Id = 101, Name = "Secador"}
                );

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
