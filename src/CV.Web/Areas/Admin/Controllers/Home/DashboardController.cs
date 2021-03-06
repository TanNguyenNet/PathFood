﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers.Home
{
    public class DashboardController : BaseController
    {
        [Route(AdminEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}