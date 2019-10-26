using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers
{
    public class DocumentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}