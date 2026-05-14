using ecommerce.api.Models.Domain.Entities.Employees.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.AddressCon
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(a => a.UserApp).WithMany(ua => ua.Addresses).HasForeignKey(ua => ua.UserAppId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Country).WithMany(ua => ua.Address).HasForeignKey(ua => ua.CountryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.City).WithMany(ua => ua.Address).HasForeignKey(ua => ua.CityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Town).WithMany(ua => ua.Address).HasForeignKey(ua => ua.TownId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
