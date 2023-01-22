using Microsoft.AspNetCore.Mvc;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public Account GetAccount(int id)
        {
            return _accountRepository.Get(id);
        }

        [HttpPost]
        public Account AddAccount(int id, string username, string password, string role)
        {
            return _accountRepository.Add(new Account() { Id = id, Username = username, Password = password, Role = role });
        }

        [HttpPut]
        public void UpdateAccount(int id, string username, string password, string role)
        {
            _accountRepository.Update(id, username, password, role);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _accountRepository.Delete(id);
        }
    }
}
