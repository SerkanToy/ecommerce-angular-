using ecommerce.api.Models.Domain.Entities.Users;
using electronik.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ecommerce.api.Models.Context
{
    public class EcommerceDbContext : IdentityDbContext<UserApp, RoleApp, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options): base(options)
        {
            
        }
    }
}
