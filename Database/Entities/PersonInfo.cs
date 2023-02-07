using System.ComponentModel.DataAnnotations.Schema;

namespace Person_Registration_System.Database.Entities
{
    public class PersonInfo
    {
  
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; } 
        public long PersonalCode { get; set; }
        public long PhoneNumber { get; set; }    
        public string EmailAddress { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

      //  public Photo Photo { get; set; }
  
        public PersonInfo()
        {
        }


    }
}
