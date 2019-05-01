using LangDriver.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LangDriver.Common.Interfaces
{
    public interface IUserRepository
    {
        User Get(string login, string password);
        Dictionary<string, string> GetDictionaryById(Guid id);
    }
}
