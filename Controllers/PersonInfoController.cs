using Microsoft.AspNetCore.Mvc;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonInfoController : ControllerBase
    {
        private readonly IPersonInfoRepository _personinfoRepository;
        public PersonInfoController(IPersonInfoRepository personInfoRepository)
        {
            _personinfoRepository = personInfoRepository;
        }

        [HttpGet]
        public PersonInfo GetPersonInfo(int id)
        {
            return _personinfoRepository.Get(id);
        }

        [HttpPost]
        public PersonInfo AddPersonInfo(int id, string name, string surname, int personalCode, int phoneNumber, string emailAddress)
        {
            return _personinfoRepository.Add(new PersonInfo() { Id = id, Name = name, Surname = surname, PersonalCode = personalCode, PhoneNumber = phoneNumber, EmailAddress = emailAddress});
        }

        [HttpPut]
        public void UpdatePersonInfo(int id, string name, string surname, int personalCode, int phoneNumber, string emailAddress)
        {
            _personinfoRepository.Update(id, name, surname, personalCode, phoneNumber, emailAddress);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _personinfoRepository.Delete(id);
        }

    }
}
