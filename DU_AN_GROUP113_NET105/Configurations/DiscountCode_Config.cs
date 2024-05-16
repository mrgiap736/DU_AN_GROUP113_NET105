using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class DiscountCode_Config : IEntityTypeConfiguration<DiscountCode>
    {
        public void Configure(EntityTypeBuilder<DiscountCode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Cart).WithMany(x => x.DiscountCodes).HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.DiscountCategory).WithMany(x => x.DiscountCodes).HasForeignKey(x => x.CategoryId);
        }
    }
}
