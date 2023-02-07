using Microsoft.AspNetCore.Mvc;
using Person_Registration_System.Database.Entities;
using Person_Registration_System.Interfaces;

namespace Person_Registration_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public User GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        [HttpPost]
        public User AddUser(string username, string password, string role)
        {
            return _userRepository.Add(new User() {Username = username, Password = password, Role = role });
        }

        [HttpPut]
        public void UpdateUser(int id, string username, string password, string role)
        {
            _userRepository.Update(id, username, password, role);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
