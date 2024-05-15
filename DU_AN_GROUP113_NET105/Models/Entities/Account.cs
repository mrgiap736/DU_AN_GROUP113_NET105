namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //Quan he
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
