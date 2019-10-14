using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers.Settings
{
    public class WebImageController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(string id)
        {
            ViewBag.imageId = id;
            return View();
        }

    }
}