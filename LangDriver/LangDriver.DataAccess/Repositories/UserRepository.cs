using System;
using System.Collections.Generic;
using System.Linq;
using LangDriver.Common.Interfaces;
using LangDriver.Common.Models;

namespace LangDriver.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private List<User> userList = new List<User>
        {
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Login = "garry",
                Password = "potter"

            },
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Login = "lady",
                Password = "fox"

            }
        };

        public User Get(string login, string password)
        {
            return userList.SingleOrDefault(u => u.Login == login && u.Password == password);
        }

        public Dictionary<string, string> GetDictionaryById(Guid id)
        {
            return userList.FirstOrDefault(u => u.Id == id)?.Dictionary;
        }
    }
}
