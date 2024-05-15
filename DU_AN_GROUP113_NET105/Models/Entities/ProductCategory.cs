namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Sort { get; set; }
        
        //Quan he
        public virtual ICollection<Product> Products { get; set; }
    }
}
