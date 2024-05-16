namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }      
        public string Phone { get; set; }
        public string Address { get; set; }

        //Quan he
        public Cart? Cart { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
