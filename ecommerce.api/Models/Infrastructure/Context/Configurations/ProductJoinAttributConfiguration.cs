using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class ProductJoinAttributConfiguration : IEntityTypeConfiguration<ProductJoinAttribut>
    {
        public void Configure(EntityTypeBuilder<ProductJoinAttribut> builder)
        {
            builder.ToTable("ProductJoinAttribut");
            builder.HasOne(c => c.Product).WithMany(pjc => pjc.ProductJoinAttributs).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Attributs).WithMany(pjc => pjc.ProductJoinAttributs).HasForeignKey(pjc => pjc.AttributId).OnDelete(DeleteBehavior.NoAction);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<ProductJoinAttribut> builder)
        {
            builder.HasOne(c => c.Product).WithMany(pjc => pjc.ProductJoinAttributs).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Attributs).WithMany(pjc => pjc.ProductJoinAttributs).HasForeignKey(pjc => pjc.AttributId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
