namespace Person_Registration_System.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }    

        public string Role { get; set; }

        public PersonInfo PersonInfo { get; set; }

        public User()
        {

        }
    }  
}
