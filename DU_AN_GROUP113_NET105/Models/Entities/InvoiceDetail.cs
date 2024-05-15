namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class InvoiceDetail
    {
        public Guid Id { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal PromotionPrice { get; set; }
        public int Quantity { get; set; }

        //Quan he
        public Guid ProductId { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

    }
}
