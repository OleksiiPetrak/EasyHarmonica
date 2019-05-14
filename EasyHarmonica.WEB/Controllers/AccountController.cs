using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EasyHarmonica.WEB.Models;
using AutoMapper;
using System;

namespace EasyHarmonica.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            //await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await _userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("GetChapters", "Chapter");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            //await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    City = model.City,
                    Name = model.Name,
                    Role = "User",
                    BirthDay = model.BirthDay
                };
                await _userService.Create(userDto);
                return RedirectToAction("GetChapters", "Chapter");
            }
            return View(model);
        }

        public async Task<ViewResult> GetUserInfo()
        {
            var email = User.Identity.Name;
            var userDto = await _userService.GetUser(email);
            if(userDto == null)
            {
                throw new ArgumentNullException();
            }
            var model = Mapper.Map<UserDTO, UserModel>(userDto);
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await _userService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                City = "Kharkiv",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}