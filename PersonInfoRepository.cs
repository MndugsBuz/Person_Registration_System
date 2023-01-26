using Person_Registration_System.Database;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System
{
    public class PersonInfoRepository : IPersonInfoRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PersonInfo Add(PersonInfo personinfo)
        {
            var newPersonInfo = new PersonInfo
            {
                UserId = personinfo.UserId,
                Name = personinfo.Name,
                Surname = personinfo.Surname,
                PersonalCode = personinfo.PersonalCode,
                PhoneNumber = personinfo.PhoneNumber,
                EmailAddress =  personinfo.EmailAddress,

            };

            _context.PersonsInfo.Add(newPersonInfo);
            _context.SaveChanges();
            return newPersonInfo;
        }
        public PersonInfo Get(int id)
        {
            return _context.PersonsInfo.SingleOrDefault(x => x.Id == id);
        }

        public PersonInfo Update(int id, string name, string surname, int personalcode, int phonenumber, string emailaddress)
        {
            var personinfoToUpdate = _context.PersonsInfo.Single(x => x.UserId == id);

            personinfoToUpdate.UserId = id;
            personinfoToUpdate.Name = name;
            personinfoToUpdate.Surname = surname;
            personinfoToUpdate.PersonalCode = personalcode;
            personinfoToUpdate.PhoneNumber = phonenumber;
            personinfoToUpdate.EmailAddress = emailaddress;
            _context.SaveChanges();

            return personinfoToUpdate;
        }

        public PersonInfo Delete(int id)
        {
            var personinfoToDetele = _context.PersonsInfo.Single(x => x.Id == id);
            _context.Remove(personinfoToDetele);
            _context.SaveChanges();
            return personinfoToDetele;
        }

    }
}
