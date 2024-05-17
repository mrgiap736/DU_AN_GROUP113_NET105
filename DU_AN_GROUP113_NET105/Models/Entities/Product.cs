using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public byte[]? Image { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PromotionPrice { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string Details { get; set; }

        //các quan hệ 
        public Guid? BrandId { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public Guid? SupplierId { get; set; }

        public Brand? Brand { get; set; }
        public Supplier? Supplier { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }

    }
}
