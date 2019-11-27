using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Entities.Catalog;
using CV.Data.Model.Page;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Catalog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostService _postService;
        private readonly IWebImageService _webImageService;
        private readonly ICatalogFunctionService _catalogFunctionService;
        private readonly ICatalogSectorService _catalogSectorService;
        private readonly ICategoryBlogService _categoryBlogService;

        public HomeController(IPostService postService,
            IWebImageService webImageService,
            ICatalogFunctionService catalogFunctionService,
            ICatalogSectorService catalogSectorService,
            ICategoryBlogService categoryBlogService)
        {
            _postService = postService;
            _webImageService = webImageService;
            _catalogFunctionService = catalogFunctionService;
            _catalogSectorService = catalogSectorService;
            _categoryBlogService = categoryBlogService;
        }

        [Route(HomeEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeModel();

            model.Images = _webImageService.GetAll(Data.Enum.Position.HomeSlide);
            
            model.PostsHot = _postService.GetAll(CurrentLang, 2, true, active: true, publishDate: true);
            model.CatalogFunctions = _catalogFunctionService.GetAll(CurrentLang, true, true);
            model.Logos = _webImageService.GetAll(Data.Enum.Position.Logo);

            foreach (var item in model.CatalogFunctions)
            {
                item.Product = item.Product.Where(x => x.New == true).ToList();
            }

            model.CatalogSectors = _catalogSectorService.GetAll(CurrentLang, true, true);

            foreach (var item in model.CatalogSectors)
            {
                item.Product = item.Product.Where(x => x.New == true).ToList();
            }

            model.Category = _categoryBlogService.GetAll(CurrentLang);

            foreach (var item in model.Category)
            {
                var posts = _postService.GetPagedAll(1, 4, publishDate: true, lang: CurrentLang, cat: item.Slug);
                if (model.Posts is null)
                    model.Posts = posts.Results;
                else
                {
                    var tmp = model.Posts.ToList();
                    foreach (var post in posts.Results)
                    {
                        tmp.Add(post);
                    }
                    model.Posts = tmp;
                }
            }

            return View(model);
        }


    }
}