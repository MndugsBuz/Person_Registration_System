using Person_Registration_System.Database.Entities;

namespace Person_Registration_System
{
    public interface IAccountRepository
    {
        Account Add(Account account);
        Account Get(int id);
        Account Update(int id, string username, string password, string role);
        Account Delete(int id);
    }
}
