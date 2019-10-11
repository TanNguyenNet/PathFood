using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class ContactController : BaseController
    {

        [Route(ContactEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route(ContactEndpoints.SendContactEndPoint)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendContact()
        {
            return RedirectToAction("Index");
        }
    }
}