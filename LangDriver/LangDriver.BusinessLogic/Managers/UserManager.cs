using LangDriver.BusinessLogic.Interfaces;
using LangDriver.Common.Interfaces;
using LangDriver.Common.Models;
using LangDriver.DataAccess.Repositories;
using System;
using System.Collections.Generic;

namespace LangDriver.BusinessLogic.Managers
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Get(string login, string password)
        {
            return _userRepository.Get(login, password);
        }

        public Dictionary<string,string> GetDictionaryById(Guid id)
        {
            return _userRepository.GetDictionaryById(id);
        }
    }
}
