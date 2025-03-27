using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using TopTenShop.Core.Convertors;
using TopTenShop.Core.DTOs.User;
using TopTenShop.Core.Generator;
using TopTenShop.Core.Security;
using TopTenShop.Core.Senders;
using TopTenShop.Core.Services.Interface;
using TopTenShop.DataLayer.Entities.User;

namespace TopTenShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IViewRenderService _ViewRender;
        public AccountController(IUserService userService,IViewRenderService renderService)
        {

            _userService = userService;
            _ViewRender = renderService;
        }



        #region Register
        [Route("/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [Route("/Register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری در سیستم موجود میباشد");
                return View(register);
            }


            if (_userService.IsExistEmail(FixedText.FixEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "کاربری با این ایمیل ثبت نام شده است");
                return View(register);
            }


            User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Email = register.Email,
                IsActive = false,
                RegisterDate = DateTime.Now,
                UserName = register.UserName,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                UserAvatar = "15.jpg"

            };
            _userService.AddUser(user);
            #region SendEmail

            string body = _ViewRender.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعال سازی", body);

            #endregion

            return View("SuccesRegister", user);
        }
        #endregion


        #region LoginAndLogOut

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var user = _userService.GetUserForLogin(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                       new Claim (ClaimTypes.NameIdentifier , user.UserId.ToString()),
                       new Claim(ClaimTypes.Name , user.UserName),
                       new Claim(ClaimTypes.Email, user.Email),
                    };
                     
                    var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(Identity);

                    var propertis = new AuthenticationProperties()
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, propertis);


                    ViewBag.IsSuccess = true;
                    return View(login);
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمیباشد");
                    return View(login);
                }
            }


            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");

            return View();
        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }
        #endregion

        #region ActiveAccount
        [Route("Active/{activecode}")]
        public IActionResult ActiveAccount(string activecode)
        {
            ViewBag.IsActive = _userService.ActiveAccount(activecode);
           
            return View();
        }
        #endregion
    }
}
