using System.ComponentModel.DataAnnotations;

namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        //Quan he
        public Guid CustomerId { get; set; }
        public Guid StaffId { get; set; }

        public Staff Staff { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
