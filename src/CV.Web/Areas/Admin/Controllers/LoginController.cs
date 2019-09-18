using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Entities.Identity;
using CV.Web.Areas.Admin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        private readonly SignInManager<AppUser> _signInManager;

        
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("MsgError", "Tài khoản đã bị khóa");
                    return View();
                }
                else
                {
                    //return new ObjectResult(new GenericResult(false, "Đăng nhập sai"));
                    ModelState.AddModelError("MsgError", "Đăng nhập sai");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("MsgError", "Tên đăng nhập hoặc mật khẩu không đúng.");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}