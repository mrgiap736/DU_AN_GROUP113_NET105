namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class DiscountCategory
    {
        public Guid Id { get; set; }
        public int Type {  get; set; }
        public int Category {  get; set; }

        //Quan he
        public virtual ICollection<DiscountCode> DiscountCodes { get; set; }
    }
}
