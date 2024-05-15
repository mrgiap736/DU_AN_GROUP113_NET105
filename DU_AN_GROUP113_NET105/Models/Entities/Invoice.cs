namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }      
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        //Quan he
        public Guid UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
