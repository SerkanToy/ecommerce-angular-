using ecommerce.api.Models.Domain.Entities.Employees.Address;
using ecommerce.api.Models.Infrastructure.Context.Configurations.UserCon;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Domain.Entities.Users
{
    public class UserApp: IdentityUser<Guid>
    {
        public UserApp()
        {
            Id = Guid.CreateVersion7();
            IsActive = true;
            IsDeleted = false;
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Salt { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
        public ICollection<Address>? Addresses { get; set; } 

        #region Audit Log
            public DateTimeOffset CreateAt { get; set; }
            public Guid CreateUserId { get; set; } = default!;
            public DateTimeOffset? UpdateAt { get; set; }
            public Guid? UpdateUserId { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
            public DateTimeOffset? DeleteAt { get; set; }
            public Guid? DeleteUserId { get; set; }
        #endregion
    }
}
