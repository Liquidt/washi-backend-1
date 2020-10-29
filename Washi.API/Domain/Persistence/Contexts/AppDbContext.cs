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
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<District> Districts { get; set; }

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

            /*builder.Entity<UserProfile>().HasData
                (
                    new UserProfile { Id = 1, UserId = 1, FirstName = "Felipe", LastName = "Kacomt", Sex = ESex.Female, Address = "Chiclayo", PhoneNumber = 987654321, UserType = EUserType.Washer },
                    new UserProfile { Id = 2, UserId = 2, CorporationName = "Xavistian Inc", Address = "Watchflowers", PhoneNumber = 999888777, UserType = EUserType.Laundry }
                );
            */

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

            // Subscription Entity
            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Subscription>().Property(p => p.Price).IsRequired();
            builder.Entity<Subscription>().Property(p => p.DurationInDays).IsRequired();
            builder.Entity<Subscription>().HasData
                (
                    new Subscription { Id = 1, Name = "WasherPremium 1 mes", Price = Convert.ToDecimal(15.00), DurationInDays = 30 },
                    new Subscription { Id = 2, Name = "WasherPremium 3 meses", Price = Convert.ToDecimal(40.00), DurationInDays = 90 },
                    new Subscription { Id = 3, Name = "LaundryPremium 1 mes", Price = Convert.ToDecimal(100.00), DurationInDays = 30 },
                    new Subscription { Id = 4, Name = "LaundryPremium 3 meses", Price = Convert.ToDecimal(280.00), DurationInDays = 90 }
                );

            //UserSubscription Entity
            builder.Entity<UserSubscription>().ToTable("UserSubscriptions");
            builder.Entity<UserSubscription>()
                .HasKey(p => new { p.UserId, p.SubscriptionId });

            builder.Entity<UserSubscription>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserSubscriptions)
                .HasForeignKey(p => p.UserId);

            builder.Entity<UserSubscription>()
                .HasOne(p => p.Subscription)
                .WithMany(p => p.UserSubscriptions)
                .HasForeignKey(p => p.SubscriptionId);

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
            //Currency Entity
            builder.Entity<Currency>().ToTable("Currencies");
            builder.Entity<Currency>().HasKey(c => c.Id);
            builder.Entity<Currency>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Currency>().Property(c => c.Symbol).IsRequired().HasMaxLength(5);
            builder.Entity<Currency>().HasData
                (
                    new Currency { Id = 2, Name = "Dólar Estadounidense", Symbol = "$" },
                    new Currency { Id = 1, Name = "Sol", Symbol = "S/" },
                    new Currency { Id = 3, Name = "Euro", Symbol = "€" }
                );

            //CountryCurrency
            builder.Entity<CountryCurrency>().ToTable("CountryCurrencies");
            builder.Entity<CountryCurrency>().HasKey(cc => cc.Id);
            builder.Entity<CountryCurrency>().Property(cc => cc.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CountryCurrency>().HasOne(cc => cc.Country).WithMany(c => c.CountryCurrencies).HasForeignKey(cc => cc.CountryId);
            builder.Entity<CountryCurrency>().HasOne(cc => cc.Currency).WithMany(c => c.CountryCurrencies).HasForeignKey(cc => cc.CurrencyId);
            builder.Entity<CountryCurrency>().HasData
                (
                    new CountryCurrency { Id = 1, CountryId = 1, CurrencyId = 1 },
                    new CountryCurrency { Id = 2, CountryId = 1, CurrencyId = 2 },
                    new CountryCurrency { Id = 3, CountryId = 1, CurrencyId = 3 },
                    new CountryCurrency { Id = 4, CountryId = 2, CurrencyId = 2 }
                );
            //Country Entity
            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(c => c.Id);
            builder.Entity<Country>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Country>().HasMany(c => c.Departments).WithOne(d => d.Country).HasForeignKey(d => d.CountryId);
            builder.Entity<Country>().HasData
                (
                    new Country { Id = 1, Name = "Perú" },
                    new Country { Id = 2, Name = "Estados Unidos" }
                );
            //Department Entity
            builder.Entity<Department>().ToTable("Departments");
            builder.Entity<Department>().HasKey(c => c.Id);
            builder.Entity<Department>().Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<Department>().Property(c => c.Name)
                .IsRequired();
            builder.Entity<Department>().HasMany(p => p.Districts)
                                        .WithOne(p => p.Department)
                                        .HasForeignKey(p => p.DepartmentId);
            builder.Entity<Department>().HasData
                (
                    new Department { Id = 1, Name = "Lima", CountryId = 1 },
                    new Department { Id = 2, Name = "La Libertad", CountryId = 1 }
                );
            //District Entity
            builder.Entity<District>().ToTable("Districts");
            builder.Entity<District>().HasKey(d => d.Id);
            builder.Entity<District>().Property(d => d.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<District>().Property(d => d.Name)
                .IsRequired();
            builder.Entity<District>().HasMany(p => p.UserProfiles)
                                      .WithOne(p => p.District)
                                      .HasForeignKey(p => p.DistrictId);
            builder.Entity<District>().HasData
                (
                    new District { Id = 1, Name = "Miraflores", DepartmentId = 1 },
                    new District { Id = 2, Name = "Barranco", DepartmentId = 1 },
                    new District { Id = 3, Name = "San Isidro", DepartmentId = 1 },
                    new District { Id = 4, Name = "Chaclacayo", DepartmentId = 1 },
                    new District { Id = 5, Name = "Chiclayo", DepartmentId = 2 }
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
