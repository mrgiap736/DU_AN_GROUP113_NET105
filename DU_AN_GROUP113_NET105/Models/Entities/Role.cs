using System.ComponentModel.DataAnnotations;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public int Status { get; set; }

        //Quan he
        public virtual List<Staff> Staffs { get; set; }
    }
}
