using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class ProductCategory_Config : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Products).WithOne(x => x.ProductCategory).HasForeignKey(x => x.ProductCategoryId);
        }
    }
}
