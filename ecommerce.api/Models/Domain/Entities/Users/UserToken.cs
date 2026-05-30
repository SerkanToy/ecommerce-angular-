using Microsoft.AspNetCore.Identity;
using System;

namespace ecommerce.api.Models.Domain.Entities.Users
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
    }
}
