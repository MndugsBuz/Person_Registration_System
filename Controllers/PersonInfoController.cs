using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Person_Registration_System.Database.Entities;
using Person_Registration_System.Interfaces;

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

        public PersonInfo AddPersonInfo(int userId, string name, string surname, long personalCode, long phoneNumber, string emailAddress)
        {
            return _personinfoRepository.Add(new PersonInfo() {UserId = userId, Name = name, Surname = surname, PersonalCode = personalCode, PhoneNumber = phoneNumber, EmailAddress = emailAddress});
        }

        [HttpPut]
        public void UpdatePersonInfo(int userId, string name, string surname, long personalCode, long phoneNumber, string emailAddress)
        {
            _personinfoRepository.Update(userId, name, surname, personalCode, phoneNumber, emailAddress);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _personinfoRepository.Delete(id);
        }

    }
}
