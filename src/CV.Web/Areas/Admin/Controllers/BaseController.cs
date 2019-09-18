using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class BaseController : Controller
    {

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}