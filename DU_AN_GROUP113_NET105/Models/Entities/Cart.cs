namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Cart
    {
        public int Status { get; set; }
        
        //Quan he
        public Guid UserId { get; set; }
        public string DiscountId { get; set; } 
        
        public User User { get; set; }
        public virtual ICollection<DiscountCode>? DiscountCodes { get; set; }
    }
}
