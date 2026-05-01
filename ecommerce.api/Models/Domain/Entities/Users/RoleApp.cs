using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.api.Models.Domain.Entities.Users
{
    public class RoleApp: IdentityRole<string>
    {
        [NotMapped]
        public ICollection<UserRoleApp>? UserRoles { get; set; }
    }
}
