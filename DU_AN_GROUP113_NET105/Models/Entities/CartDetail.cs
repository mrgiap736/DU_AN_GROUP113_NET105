namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal PromotionPrice { get; set; }
        public int Quantity { get; set; }

        //Quan he
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
