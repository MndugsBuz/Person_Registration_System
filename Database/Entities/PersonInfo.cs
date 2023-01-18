using System.ComponentModel.DataAnnotations.Schema;

namespace Person_Registration_System.Database.Entities
{
    public class PersonInfo
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; } 
        public int PersonalCode { get; set; }
        public int PhoneNumber { get; set; }    
        public string EmailAddress { get; set; }
        public List<ResidenceAddress> AddressList { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public PersonInfo()
        {
        }


    }
}
