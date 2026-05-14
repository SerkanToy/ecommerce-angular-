using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {  
            builder.HasKey(rc => rc.Id);
            ConfigureRelations(builder);
            Datas(builder);
        }

        private void ConfigureRelations(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(c => c.ProductJoinCategori).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.ProductsJoinTags).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.ProductJoinCoupons).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.ProductJoinAttributs).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Galleries).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.NoAction);
        }

        private void Datas(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new List<Product>()
            {
                new Product ()
                {
                    Name = "Product 1",
                    Description = "Description 1",
                    RegulerPrice = 100,
                    DiscountPrice = 90,
                    Note = "Note 1",
                    icon = "icon1.png"
                },
                new Product()
                {
                    Name = "Product 2",
                    Description = "Description 2",
                    RegulerPrice = 200,
                    DiscountPrice = 180,
                    Note = "Note 2",
                    icon = "icon2.png"
                },
                new Product()
                {
                    Name = "Product 3",
                    Description = "Description 3",
                    RegulerPrice = 300,
                    DiscountPrice = 270,
                    Note = "Note 3",
                    icon = "icon3.png"
                }
            });
        }


    }
}
