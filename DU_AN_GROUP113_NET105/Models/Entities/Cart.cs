using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Cart
    {
        [Required]  
        public int Status { get; set; }

        //Quan he

        [Key, ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        
        public Customer Customer { get; set; }
        public virtual ICollection<DiscountCode>? DiscountCodes { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
