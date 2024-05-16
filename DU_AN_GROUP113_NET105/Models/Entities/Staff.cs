namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }

        //Quan he
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
