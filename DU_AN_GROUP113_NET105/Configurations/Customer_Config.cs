using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class Customer_Config : IEntityTypeConfiguration<Models.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Models.Entities.Customer> builder)
        {
            builder.HasKey(x => x.Id);//Khoa chinh

            //Username
            builder.HasIndex(x => x.Username).IsUnique(); //Ràng buộc là duy nhất

            //Email
            builder.HasIndex(x => x.Email).IsUnique(); //Ràng buộc là duy nhất


        }
    }
}
