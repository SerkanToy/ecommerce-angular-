using ecommerce.api.Models.Infrastructure.Context.Configurations.UserCon;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Domain.Entities.Users
{
    public class RoleApp: IdentityRole<Guid>
    {
        public RoleApp()
        {
            Id = Guid.CreateVersion7();
        }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
