using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class Cart_Config : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.HasOne(x => x.Customer).WithOne(x => x.Cart).HasForeignKey<Cart>(x => x.CustomerId);

            builder.HasMany(x => x.DiscountCodes).WithOne(x => x.Cart).HasForeignKey(x => x.CustomerId);
        }
    }
}
