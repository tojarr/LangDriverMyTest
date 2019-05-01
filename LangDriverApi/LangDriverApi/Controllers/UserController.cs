using LangDriverApi.BusinesLogic.Interfaces;
using LangDriverApi.BusinesLogic.Services;
using LangDriverApi.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LangDriverApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IEmailService _emailService;
        private const string confirmPath = "https://localhost:44316/api/account/";

        public UserController(IUserManager manager, IEmailService emailService)
        {
            _userManager = manager;
            _emailService = emailService;
        }

        /// <summary>
        /// GetUser
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="id">Identifier.</param>
        [Route("api/user/{id}")]
        [AcceptVerbs("GET")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userManager.GetUserById(id);
            return user != null
                ? StatusCode(StatusCodes.Status200OK, user)
                : NotFound(null);
        }

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="registerInfo">Register info.</param>
        [Route("api/user")]
        [AcceptVerbs("POST")]
        public async Task<IActionResult> CreateUser([FromBody]RegisterInfo registerInfo)
        {
            User user = null;
            //registerInfo.Email = "matroskin0711@gmail.com";
            if (ModelState.IsValid)
            {
                user = _userManager.CreateUser(registerInfo);
                if (user != null)
                {
                    await _emailService.SendEmailAsync(user.Email, "Confirm your account",
                            $"<h3>Confirm the registration by clicking on the link: <a href='{confirmPath}{user.Id}'>link</a></h3>");
                }
            }
            return user != null
                ? StatusCode(StatusCodes.Status201Created, "To confirm registration go to your Email.")
                : UnprocessableEntity(null);
        }

        /// <summary>
        /// DeleteUser
        /// </summary>
        /// <param name="id">Identifier.</param>
        [Route("api/user/{id}")]
        [AcceptVerbs("DELETE")]
        public IActionResult DeleteUser(Guid id)
        {
            return _userManager.DeleteUser(id)
                ? StatusCode(StatusCodes.Status200OK)
                : NotFound();
        }
    }
}