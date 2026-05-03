using ecommerce.api.Models.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.api.Models.Infrastructure.Context.Configurations
{
    public class TagsConfiguration : IEntityTypeConfiguration<Tags>
    {
        public void Configure(EntityTypeBuilder<Tags> builder)
        {
            builder.ToTable("Tags");
            ConfigureRelations(builder);
            builder.HasKey(rc => rc.Id);
        }

        private void ConfigureRelations(EntityTypeBuilder<Tags> builder)
        {
            builder.HasMany(c => c.ProductsJoinTags).WithOne(pjc => pjc.Tags).HasForeignKey(pjc => pjc.TagId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
