﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers.Settings
{
    public class InfoController : BaseController
    {

        public InfoController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update(string id)
        {
            ViewBag.infoId = id;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}