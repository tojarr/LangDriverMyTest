using LangDriverApi.Common.Models;
using System;

namespace LangDriverApi.BusinesLogic.Interfaces
{
    public interface IUserManager
    {
        User CreateUser(RegisterInfo userInfo);
        bool DeleteUser(Guid id);
        User GetUserById(Guid id);
        User GetByLogin(string email);
        bool ConfirmPass(SignInInfo info);
        void Update(User user);
    }
}
