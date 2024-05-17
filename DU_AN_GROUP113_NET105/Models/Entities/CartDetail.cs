using System.ComponentModel.DataAnnotations.Schema;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class CartDetail
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PromotionPrice { get; set; }
        public int Quantity { get; set; }

        //Quan he
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
