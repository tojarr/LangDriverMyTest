using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LangDriverApi.BusinesLogic.Interfaces;
using LangDriverApi.BusinesLogic.Services;
using LangDriverApi.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LangDriverApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IEmailService _emailService;

        public AccountController(IUserManager userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        /// <summary>
        /// ActivateAccount
        /// </summary>
        /// <returns>Complete.</returns>
        /// <param name="id">Identifier.</param>
        [Route("api/account/{id}")]
        [AcceptVerbs("GET")]
        public async Task<IActionResult> ActivateAccount(Guid id)
        {
            var user = _userManager.GetUserById(id);
            if(user != null)
            {
                user.InActive = true;
                _userManager.Update(user);
                await _emailService.SendEmailAsync(user.Email, "Complete registration",
                        "Your registration is complete");
            }
            return user != null
                ? StatusCode(StatusCodes.Status200OK, "Complete")
                : NotFound(null);
        }

        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="info">SignIn info.</param>
        [Route("api/account")]
        [AcceptVerbs("POST")]
        public IActionResult SignIn([FromBody]SignInInfo info)
        {
            if (_userManager.ConfirmPass(info))
            {
                if (_userManager.GetByLogin(info.Login).InActive)
                {
                    var user = _userManager.GetByLogin(info.Login);
                    return StatusCode(StatusCodes.Status200OK, user);
                }
                return StatusCode(StatusCodes.Status423Locked, "Account is not active");
            }
            return StatusCode(StatusCodes.Status401Unauthorized, "Invalid login or password");
        }
    }
}