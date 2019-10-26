using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.Page;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Catalog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.WebEnglish.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostService _postService;
        private readonly IWebImageService _webImageService;
        private readonly ICatalogFunctionService _catalogFunctionService;
        private readonly ICatalogSectorService _catalogSectorService;

        public HomeController(IPostService postService,
            IWebImageService webImageService,
            ICatalogFunctionService catalogFunctionService,
            ICatalogSectorService catalogSectorService)
        {
            _postService = postService;
            _webImageService = webImageService;
            _catalogFunctionService = catalogFunctionService;
            _catalogSectorService = catalogSectorService;
        }

        [Route(HomeEndpoints.EnglishIndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeModel();
            model.Images = _webImageService.GetAll(Data.Enum.Position.HomeSlide);
            model.Posts = _postService.GetAll(CurrentLang, 4, active: true, publishDate: true);
            model.PostsHot = _postService.GetAll(CurrentLang, 2, true, active: true, publishDate: true);
            model.CatalogFunctions = _catalogFunctionService.GetAll(CurrentLang, true, true);
            foreach (var item in model.CatalogFunctions)
            {
                item.Product = item.Product.Where(x => x.New == true).ToList();
            }
            model.CatalogSectors = _catalogSectorService.GetAll(CurrentLang, true, true);
            foreach (var item in model.CatalogSectors)
            {
                item.Product = item.Product.Where(x => x.New == true).ToList();
            }
            return View(model);
        }
    }
}