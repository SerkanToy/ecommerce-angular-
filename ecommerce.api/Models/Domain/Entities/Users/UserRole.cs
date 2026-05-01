using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.UserCon
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public UserApp UserApp { get; set; }
        public RoleApp RoleApp { get; set; }
    }
}
