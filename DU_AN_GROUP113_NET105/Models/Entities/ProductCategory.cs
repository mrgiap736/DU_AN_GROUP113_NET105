using System.ComponentModel.DataAnnotations;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class ProductCategory
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int Sort { get; set; }
        
        //Quan he
        public virtual ICollection<Product> Products { get; set; }
    }
}
