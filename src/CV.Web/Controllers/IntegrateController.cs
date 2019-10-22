using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class IntegrateController : BaseController
    {

        private readonly IPageContentService _pageContentService;
        private readonly IWebImageService _webImageService;

        public IntegrateController(IPageContentService pageContentService,
            IWebImageService webImageService)
        {
            _pageContentService = pageContentService;
            _webImageService = webImageService;
        }

        [Route(IntegrateEndpoints.IndexIntegrate)]
        [HttpGet]
        public IActionResult Index(string slug)
        {
            var model = _pageContentService.GetPageSlug(slug);
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbFAQ).FirstOrDefault()?.URLImage;
            return View(model);
        }
    }
}