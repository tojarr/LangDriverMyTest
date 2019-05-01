using LangDriverApi.Common.Models;
using LangDriverApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LangDriverApi.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LangDriverContext _context;
        
        public UserRepository(LangDriverContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            var users = GetUsers().ToList();
            if (users.Any(u => u.Id == user.Id || u.Login == user.Login || u.Email == user.Email))
            {
                return null;
            }
            _context.Add(user);

            return user;

        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return true;
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login.Equals(login));
        }

        private IEnumerable<User> GetUsers()
        {
            var users = _context.Users.AsEnumerable();
            return users;
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
