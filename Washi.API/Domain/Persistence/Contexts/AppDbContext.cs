﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ServiceMaterial> ServiceMaterials { get; set; }
        public DbSet<LaundryServiceMaterial> LaundryServiceMaterials { get; set; }
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
            builder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            builder.Entity<PaymentMethod>().HasKey(p => p.Id);
            builder.Entity<PaymentMethod>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentMethod>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<PaymentMethod>().HasData
                (
                    new PaymentMethod { Id = 1, Name = "TarjetaDeRegalo"},
                    new PaymentMethod { Id = 2, Name = "TarjetaConeyPark" }
                );

            // UserPaymentMethod Entity
            builder.Entity<UserPaymentMethod>().ToTable("UserPaymentMethods");
            builder.Entity<UserPaymentMethod>()
                .HasKey(p => new { p.UserId, p.PaymentMethodId });

            builder.Entity<UserPaymentMethod>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserPaymentMethods)
                .HasForeignKey(p => p.UserId);

            builder.Entity<UserPaymentMethod>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(p => p.UserPaymentMethods)
                .HasForeignKey(p => p.PaymentMethodId);
                

            // Service Entity
            builder.Entity<Service>().ToTable("Services");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Service>().HasData
                (
                    new Service { Id = 100, Name = "LavadoalSeco" },
                    new Service { Id = 101, Name = "Planchado" }
                );

            //Material Entity
            builder.Entity<Material>().ToTable("Materials");
            builder.Entity<Material>().HasKey(p => p.Id);
            builder.Entity<Material>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Material>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Material>().HasData
                (
                    new Material { Id = 100, Name = "Plancha"},
                    new Material { Id = 101, Name = "Secador"}
                );

            //ServiceMaterial Entity
            builder.Entity<ServiceMaterial>().ToTable("ServiceMaterials");
            builder.Entity<ServiceMaterial>().HasKey(p => p.Id);
            builder.Entity<ServiceMaterial>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ServiceMaterial>().Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Entity<ServiceMaterial>()
                .HasOne(p => p.Material)
                .WithMany(p => p.ServiceMaterials)
                .HasForeignKey(p => p.MaterialId);
            builder.Entity<ServiceMaterial>()
                .HasOne(p => p.Service)
                .WithMany(p => p.ServiceMaterials)
                .HasForeignKey(p => p.ServiceId);
            builder.Entity<ServiceMaterial>().HasData
                (
                    new ServiceMaterial { Id= 100, Name = "Lavado con lavadora al seco" },
                    new ServiceMaterial { Id= 101, Name = "Planchado con plancha fria" }
                );

            //LaundryServiceMaterial Entity
            builder.Entity<LaundryServiceMaterial>().ToTable("LaundryServiceMaterials");
            builder.Entity<LaundryServiceMaterial>().HasKey(p => p.Id);
            builder.Entity<LaundryServiceMaterial>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<LaundryServiceMaterial>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Entity<LaundryServiceMaterial>().Property(p => p.Price).IsRequired();
            builder.Entity<LaundryServiceMaterial>().Property(p => p.Rating).IsRequired();
            builder.Entity<LaundryServiceMaterial>().Property(p => p.Discount);
            builder.Entity<LaundryServiceMaterial>()
                .HasOne(p => p.User)
                .WithMany(p => p.LaundryServiceMaterials)
                .HasForeignKey(p => p.UserId);
            builder.Entity<LaundryServiceMaterial>()
                .HasOne(p => p.ServiceMaterial)
                .WithMany(p => p.LaundryServiceMaterials)
                .HasForeignKey(p => p.ServiceMaterialId);
            builder.Entity<LaundryServiceMaterial>().HasData
                (
                    new LaundryServiceMaterial { Id = 100, Description = "Lavado con lavadora al seco al estilo de lavanderia pepito", Price=100.5F, Rating=5},
                    new LaundryServiceMaterial { Id = 101, Description = "Planchado con plancha fria al estilo lavanderia pepito", Price = 100.5F, Rating = 5 }
                );


            //SnakeCase convention apply
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
