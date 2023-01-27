using Microsoft.AspNetCore.Mvc;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResidenceAddressController : ControllerBase
    {
        private readonly IResidenceAddressRepository _residenceAddressRepository;
        public ResidenceAddressController(IResidenceAddressRepository residenceAddressRepository)
        {
            _residenceAddressRepository = residenceAddressRepository;
        }

        [HttpGet]
        public Address GetResidenceAddress(int id)
        {
            return _residenceAddressRepository.Get(id);
        }

        [HttpPost]
        public Address AddResidenceAddress(int personInfoId, string city, string street, string houseNumber, string flatNumber)
        {
            return _residenceAddressRepository.Add(new Address() { PersonInfoId = personInfoId, City = city, Street = street, HouseNumber = houseNumber, FlatNumber = flatNumber});
        }

        [HttpPut]
        public void UpdateResidenceAddress(int id, string city, string street, string houseNumber, string flatNumber)
        {
            _residenceAddressRepository.Update(id, city, street, houseNumber, flatNumber);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _residenceAddressRepository.Delete(id);
        }
    }
}
