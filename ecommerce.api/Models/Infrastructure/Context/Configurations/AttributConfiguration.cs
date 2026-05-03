using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class AttributConfiguration : IEntityTypeConfiguration<Attributs>
    {
        public void Configure(EntityTypeBuilder<Attributs> builder)
        {
            builder.ToTable("Attributes");
            builder.HasKey(rc => rc.Id);
            ConfigureRelations(builder);
        }

        private void ConfigureRelations(EntityTypeBuilder<Attributs> builder)
        {
            builder.HasMany(c => c.ProductJoinAttributs).WithOne(pjc => pjc.Attributs).HasForeignKey(pjc => pjc.AttributId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
