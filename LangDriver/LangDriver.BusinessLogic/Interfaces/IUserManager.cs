using LangDriver.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LangDriver.BusinessLogic.Interfaces
{
    public interface IUserManager
    {
        User Get(string login, string password);
        Dictionary<string, string> GetDictionaryById(Guid id);
    }
}
