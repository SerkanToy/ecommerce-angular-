using ecommerce.api.Models.Domain.Entities.Users;
using ecommerce.api.Models.Infrastructure.Context.Configurations.UserCon;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ecommerce.api.Models.Infrastructure.Context;

public class EcommerceDbContext : IdentityDbContext<UserApp, RoleApp, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
    {

    }

    protected void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
