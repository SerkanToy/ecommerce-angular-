using ecommerce.api.Models.Domain.Entities.Employees.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.AddressCon
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
            builder.HasData(GetCountry());
        }

        private void ConfigureRelations(EntityTypeBuilder<Country> builder)
        {
            builder.HasMany(c => c.City).WithOne(c => c.Country).HasForeignKey(c => c.CountryId);
        }

        private List<Country> GetCountry()
        {
            var country = new List<Country> {
                new Country
                {
                    Name = "Turkey"
                },
                new Country
                {
                    Name = "Almanya"
                },
                new Country
                {
                    Name = "ABD"
                },
                new Country
                {
                    Name = "Çin"
                },
                new Country
                {
                    Name = "Kore Cumhuriyeti"
                }
            };
            return country;
        }
    }
}
