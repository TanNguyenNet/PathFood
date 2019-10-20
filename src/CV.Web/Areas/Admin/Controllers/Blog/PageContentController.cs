using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Service.Interface.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers.Blog
{
    public class PageContentController : BaseController
    {

        public PageContentController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update(string id)
        {
            ViewBag.pageId = id;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}