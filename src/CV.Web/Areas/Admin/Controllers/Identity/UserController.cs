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


        //[Authorize(Policy = nameof(ContantPolicy.Admin.ManageAdminData))]
        public IActionResult Index(int page = 1, int pageSize = 20, string filter = "")
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(string id)
        {
            ViewBag.userId = id;
            return View();
        }

        
    }
}