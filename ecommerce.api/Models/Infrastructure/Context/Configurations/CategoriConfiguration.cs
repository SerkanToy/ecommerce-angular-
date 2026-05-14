using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class CategoriConfiguration : IEntityTypeConfiguration<Categori>
    {
        public void Configure(EntityTypeBuilder<Categori> builder)
        {
            builder.ToTable("Categori");
            builder.HasKey(rc => rc.Id);
            ConfigureRelations(builder);
            Datas(builder);
        }

        private void ConfigureRelations(EntityTypeBuilder<Categori> builder)
        {
           builder.HasMany(c => c.ProductJoinCategori).WithOne(pjc => pjc.Categori).HasForeignKey(pjc => pjc.CategoriId).OnDelete(DeleteBehavior.NoAction);
        }

        private void Datas(EntityTypeBuilder<Categori> builder)
        {
            builder.HasData(new List<Categori>()
            {
                new Categori ()
                {
                    Name = "Categori 1",
                    Description = "Description 1",
                    icon = "icon1.png"
                },
                new Categori()
                {
                    Name = "Categori 2",
                    Description = "Description 2",
                    icon = "icon2.png"
                },
                new Categori()
                {
                    Name = "Categori 3",
                    Description = "Description 3",
                    icon = "icon3.png"
                }
            });
        }
    }
}
