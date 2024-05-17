using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class CartDetail_Config : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
