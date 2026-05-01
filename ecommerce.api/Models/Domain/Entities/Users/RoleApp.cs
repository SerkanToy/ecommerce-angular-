using Microsoft.AspNetCore.Identity;
using System;

namespace ecommerce.api.Models.Domain.Entities.Users
{
    public class RoleApp: IdentityRole<Guid>
    {
        public RoleApp()
        {
            Id = Guid.CreateVersion7();
        }
    }
}
