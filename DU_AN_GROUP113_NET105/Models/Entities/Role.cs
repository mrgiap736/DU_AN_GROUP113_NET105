namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        //Quan he
        public virtual List<Account> Accounts { get; set; }
    }
}
