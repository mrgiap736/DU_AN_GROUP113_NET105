using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class DiscountCategory_Config : IEntityTypeConfiguration<DiscountCategory>
    {
        public void Configure(EntityTypeBuilder<DiscountCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.DiscountCodes).WithOne(x => x.DiscountCategory).HasForeignKey(x => x.DiscountCategoryId);
        }
    }
}
