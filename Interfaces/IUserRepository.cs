using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        User Get(int id);
        User Update(int id, string username, string password, string role);
        User Delete(int id);
    }
}
