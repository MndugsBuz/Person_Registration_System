using Person_Registration_System.Database;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Add(User account)
        {
            var newUser = new User
            {
                //Id = _context.Count == 0 ? 1 : _context.Max(x => x.Id) + 1,
                //Id = account.Id + 1,
                Username = account.Username,
                Password = account.Password,
                Role = account.Role
            };
           
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public User Get(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public User Update(int id, string username, string password, string role)
        {
            //var accountToUpdate = Get(id);

            var accountToUpdate = _context.Users.Single(x => x.Id == id);

            accountToUpdate.Username = username;
            accountToUpdate.Password = password;
            accountToUpdate.Role = role;    
            _context.SaveChanges();

            return accountToUpdate;
        }

        public User Delete(int id)
        {
            var accountToDetele = _context.Users.Single(x => x.Id == id);
            _context.Remove(accountToDetele);
            _context.SaveChanges();
            return accountToDetele;
        }
    }
}
