using DU_AN_GROUP113_NET105.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DU_AN_GROUP113_NET105.Areas
{
    public class Brand_Config : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //Đối với khóa chính thì dùng HasKey
            builder.HasKey(x => x.Id);
            // HasMaxLength là đặt giới hạn kí tự cho trường dữ liệu
            // IsRequired là bắt buộc phải có dữ liệu
            builder.Property(x => x.Name).IsRequired();
            //Quan hệ 1-n
            //Cách 1: thông qua Fluent API (ở đây là cách 1)
            // builder.HasMany rồi đến tên bảng mà nó liên kết đến (ở đây là Products)
            // WithOne là quay lại bảng hiện tại (ở đây là Brand)
            // HasForeignKey là khóa ngoại
            // BrandId là khóa ngoại của bảng Products
            builder.HasMany(x => x.Products).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId);
        }
    }
}
