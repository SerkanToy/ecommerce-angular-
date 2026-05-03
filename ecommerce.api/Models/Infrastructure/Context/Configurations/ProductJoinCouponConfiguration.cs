using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class ProductJoinCouponConfiguration : IEntityTypeConfiguration<ProductJoinCoupon>
    {
        public void Configure(EntityTypeBuilder<ProductJoinCoupon> builder)
        {
            builder.ToTable("ProductJoinCoupon");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<ProductJoinCoupon> builder)
        {
            builder.HasOne(c => c.Product).WithMany(pjc => pjc.ProductJoinCoupons).HasForeignKey(pjc => pjc.CouponId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Coupon).WithMany(pjc => pjc.ProductJoinCoupons).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
