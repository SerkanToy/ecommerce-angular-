using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class GalleriConfiguration : IEntityTypeConfiguration<Galleri>
    {
        public void Configure(EntityTypeBuilder<Galleri> builder)
        {
            builder.ToTable("Galleri");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<Galleri> builder)
        {
            builder.HasOne(c => c.Product).WithMany(pjc => pjc.Galleries).HasForeignKey(pjc => pjc.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
