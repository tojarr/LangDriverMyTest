using LangDriverApi.Common.Models;
using System;

namespace LangDriverApi.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        bool DeleteUser(User user);
        User GetUserById(Guid id);
        User GetByLogin(string email);
        void Update(User user);
    }
}
