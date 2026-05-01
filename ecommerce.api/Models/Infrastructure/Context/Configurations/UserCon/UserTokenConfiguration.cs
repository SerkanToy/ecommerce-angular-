using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.UserCon
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserTokens");
            builder.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
        }
    }
}
