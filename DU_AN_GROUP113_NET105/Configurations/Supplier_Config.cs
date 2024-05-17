using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class Supplier_Config : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Products).WithOne(x => x.Supplier).HasForeignKey(x => x.SupplierId);
        }
    }
}
