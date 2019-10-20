using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Service.Interface.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class IntegrateController : BaseController
    {

        private readonly IPageContentService _pageContentService;

        public IntegrateController(IPageContentService pageContentService)
        {
            _pageContentService = pageContentService;
        }

        [Route(IntegrateEndpoints.IndexIntegrate)]
        [HttpGet]
        public IActionResult Index(string slug)
        {
            var model = _pageContentService.GetPageSlug(slug);
            return View(model);
        }
    }
}