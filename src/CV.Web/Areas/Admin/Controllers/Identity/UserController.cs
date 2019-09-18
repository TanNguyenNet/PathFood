using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Authorization;
using CV.Data.Model.Identity;
using CV.Service.Identity;
using CV.Service.Interface.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers.Identity
{
    public class UserController : BaseController
    {
        private readonly IUserIdentityService _userIdentityService;

        public UserController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }


        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult Create(AppUserModel user)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var newUser = _userIdentityService.Insert(user);
        //    }

        //    return RedirectToAction("Index");
        //}

        public IActionResult Update(string id)
        {
            ViewBag.userId = id;
            return View();
        }

        //[Authorize(Policy = nameof(ContantPolicy.User.ReadUserData))]
        public IActionResult Index(int page = 1, int pageSize = 20, string filter = "")
        {
            return View();
        }
    }
}