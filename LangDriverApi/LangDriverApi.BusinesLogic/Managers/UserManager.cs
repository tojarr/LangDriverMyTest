using LangDriverApi.BusinesLogic.Interfaces;
using LangDriverApi.BusinesLogic.Services;
using LangDriverApi.Common.Models;
using LangDriverApi.DataAccess.Interfaces;
using System;
using System.Web.Helpers;
using System.Threading.Tasks;

namespace LangDriverApi.BusinesLogic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unit;

        public UserManager(IUnitOfWork unit)
        {
            _unit = unit;
        }
        
        public User CreateUser(RegisterInfo userInfo)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = userInfo.Login,
                Password = Crypto.HashPassword(userInfo.Password),
                Email = userInfo.Email
            };
            var newUser = _unit.Users.AddUser(user);
            _unit.Save();
            return newUser;
        }

        public bool DeleteUser(Guid id)
        {
            var user = _unit.Users.GetUserById(id);
            var status = user != null ? _unit.Users.DeleteUser(user) : false;
            _unit.Save();
            return status;
        }

        public User GetUserById(Guid id)
        {
            var user = _unit.Users.GetUserById(id);
            return user;
        }

        public User GetByLogin( string login)
        {
            return _unit.Users.GetByLogin(login);
        }

        public bool ConfirmPass(SignInInfo info)
        {
            var user = GetByLogin(info.Login);
            if(user != null)
            {
                return Crypto.VerifyHashedPassword(user.Password, info.Password);
            }
            return false;
        }

        public void Update(User user)
        {
            _unit.Users.Update(user);
            _unit.Save();
        }
    }
}
