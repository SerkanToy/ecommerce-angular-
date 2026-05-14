using ecommerce.api.Models.Domain.Entities.Employees;
using ecommerce.api.Models.Domain.Entities.Employees.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations.AddressCon
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(rc => rc.Id);
            builder.HasMany(c => c.City).WithOne(c => c.Country).OnDelete(DeleteBehavior.NoAction);
            Datas(builder);
        }

        private void Datas(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new List<Country>()
            {
                new Country
                {
                    Id = Guid.CreateVersion7(),
                    Name = "Turkey"
                },
                new Country
                {
                    Id = Guid.CreateVersion7(),
                    Name = "Almanya"
                },
                new Country
                {
                    Id = Guid.CreateVersion7(),
                    Name = "ABD"
                },
                new Country
                {
                    Id = Guid.CreateVersion7(),
                    Name = "Çin"
                },
                new Country
                {
                    Id = Guid.CreateVersion7(),
                    Name = "Kore Cumhuriyeti"
                }
            });
        }
    }
}
