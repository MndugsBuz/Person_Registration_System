namespace Person_Registration_System.Database.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }    

        public string Role { get; set; }

        public List<PersonInfo> Persons { get; set; }

        public List<ResidenceAddress> ResidenceAddresses { get; set; }

        public Account()
        {

        }
    }  
}
