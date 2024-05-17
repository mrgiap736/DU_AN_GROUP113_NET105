using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class InvoiceDetail_Config : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Invoice).WithMany(x => x.InvoiceDetails).HasForeignKey(x => x.InvoiceId);
        }
    }
}
