using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class InvoiceDetail
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PromotionPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        //Quan he
        public Guid ProductId { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

    }
}
