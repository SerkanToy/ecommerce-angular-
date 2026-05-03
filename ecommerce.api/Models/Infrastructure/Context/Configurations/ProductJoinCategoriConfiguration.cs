using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class ProductJoinCategoriConfiguration : IEntityTypeConfiguration<ProductJoinCategori>
    {
        public void Configure(EntityTypeBuilder<ProductJoinCategori> builder)
        {
            builder.ToTable("ProductJoinCategori");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<ProductJoinCategori> builder)
        {
            builder.HasOne(c => c.Categori).WithMany(pjc => pjc.ProductJoinCategori).HasForeignKey(pjc => pjc.CategoriId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Product).WithMany(pjc => pjc.ProductJoinCategori).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
