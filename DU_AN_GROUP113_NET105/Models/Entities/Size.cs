using System.ComponentModel.DataAnnotations;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Size
    {
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
