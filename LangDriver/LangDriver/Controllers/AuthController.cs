using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LangDriver.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using LangDriver.BusinessLogic.Managers;
using LangDriver.BusinessLogic.Interfaces;

namespace LangDriver.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserManager _userManager;

        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
                return RedirectToActionPermanent("GetDictionary", "Dictionary");

            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthModel authModel)
        {
            if (!ModelState.IsValid)
                return View(authModel);

            
            var user = _userManager.Get(authModel.UserName.Trim(), authModel.UserPassword);

            if (user == null)
            {
                ModelState.AddModelError("default", "User or password is incorrect");
                return View(authModel);
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim("Id", user.Id.ToString())
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);


            HttpContext.SignInAsync(
                 CookieAuthenticationDefaults.AuthenticationScheme,
                 new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties());

            return RedirectToActionPermanent("GetDictionary", "Dictionary");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToActionPermanent("Login");
        }
    }
}