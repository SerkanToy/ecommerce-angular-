using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class ProductsJoinTagsConfiguration : IEntityTypeConfiguration<ProductsJoinTags>
    {
        public void Configure(EntityTypeBuilder<ProductsJoinTags> builder)
        {
            builder.ToTable("ProductsJoinTags");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<ProductsJoinTags> builder)
        {
            builder.HasOne(c => c.Product).WithMany(pjc => pjc.ProductsJoinTags).HasForeignKey(pjc => pjc.TagId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Tags).WithMany(pjc => pjc.ProductsJoinTags).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
