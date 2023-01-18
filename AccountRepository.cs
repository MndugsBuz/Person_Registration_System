﻿using Person_Registration_System.Database;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Account Add(Account account)
        {
            var newAccount = new Account
            {
                //Id = _context.Count == 0 ? 1 : _context.Max(x => x.Id) + 1,
                //Id = account.Id + 1,
                Username = account.Username,
                Password = account.Password,
                Role = account.Role
            };
           
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            return newAccount;
        }

        public Account Get(int id)
        {
            return _context.Accounts.SingleOrDefault(x => x.Id == id);
        }

        public void Update(int id, string username, string password, string role)
        {
            var account = Get(id);

            account.Username = username;
            account.Password = password;
            account.Role = role;    

            _context.SaveChanges();
        }

        public Account Delete(int id)
        {
            var accountToDetele = _context.Single(x => x.Id == id);
            _context.Remove(accountToDetele);
            return accountToDetele;
        }
    }
}
