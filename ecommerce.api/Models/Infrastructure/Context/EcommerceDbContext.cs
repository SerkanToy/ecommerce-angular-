using ecommerce.api.Models.Domain.Entities.Employees;
using ecommerce.api.Models.Domain.Entities.Employees.Address;
using ecommerce.api.Models.Domain.Entities.Users;
using ecommerce.api.Models.Infrastructure.Context.Configurations.UserCon;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace ecommerce.api.Models.Infrastructure.Context;

public class EcommerceDbContext : IdentityDbContext<UserApp, RoleApp, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
    {

    }

    // User
    public DbSet<UserApp> UserApps { get; set; }
    public DbSet<RoleApp> RoleApps { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }

    // Adress
    public DbSet<Address> Address { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Town> Towns { get; set; }

    public DbSet<Attributs> Attributs { get; set; }
    public DbSet<Categori> Categoris { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Galleri> Galleris { get; set; }
    public DbSet<Tags> Tags { get; set; }

    // Join
    public DbSet<ProductJoinAttribut> ProductJoinAttribut { get; set; }
    public DbSet<ProductJoinCategori> ProductJoinCategori { get; set; }
    public DbSet<ProductsJoinTags> ProductsJoinTags { get; set; }
    public DbSet<ProductJoinCoupon> ProductJoinCoupon { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(EcommerceDbContext).Assembly);
        base.OnModelCreating(builder);

        /*builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserClaimConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserLoginConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new UserTokenConfiguration());

            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new TownConfiguration());

            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());
            builder.ApplyConfiguration(new RoleClaimConfiguration());*/
    }
}
