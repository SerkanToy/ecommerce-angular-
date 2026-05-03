using ecommerce.api.Models.Domain.Entities.Employees.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.AddressCon
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<City> builder)
        {
            builder.HasMany(c => c.Town).WithOne(c => c.City).HasForeignKey(c => c.CityId);
            builder.HasOne(c => c.Country).WithMany(c => c.City).HasForeignKey(c => c.CountryId);
        }


    }
}
