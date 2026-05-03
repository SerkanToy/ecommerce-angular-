using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(c => c.ProductJoinCategori).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ProductsJoinTags).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ProductJoinCoupons).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ProductJoinAttributs).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Galleries).WithOne(pjc => pjc.Product).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
