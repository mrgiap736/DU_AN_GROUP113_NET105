using System.ComponentModel.DataAnnotations;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        //Quan he
        public virtual ICollection<Product> Products { get; set; }
    }
}
