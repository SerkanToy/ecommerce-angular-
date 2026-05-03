using ecommerce.api.Models.Domain.Entities.Employees.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.AddressCon
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Town");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<Town> builder)
        {
            builder.HasMany(c => c.Address).WithOne(c => c.Town).HasForeignKey(c => c.TownId);
            builder.HasOne(c => c.City).WithMany(c => c.Town).HasForeignKey(c => c.CityId);
        }
    }
}
