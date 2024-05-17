namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public byte[]? Image { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }

        //các quan hệ 
        public Guid? BrandId { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public Guid? SupplierId { get; set; }

        public Brand? Brand { get; set; }
        public Supplier? Supplier { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
