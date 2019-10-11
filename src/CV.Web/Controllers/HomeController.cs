using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class HomeController : BaseController
    {

        [Route(HomeEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       

    }
}