using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class CategoriConfiguration : IEntityTypeConfiguration<Categori>
    {
        public void Configure(EntityTypeBuilder<Categori> builder)
        {
            builder.ToTable("Categori");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<Categori> builder)
        {
           builder.HasMany(c => c.ProductJoinCategori).WithOne(pjc => pjc.Categori).HasForeignKey(pjc => pjc.CategoriId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
