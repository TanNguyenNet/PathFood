using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.WebEnglish.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ICategoryBlogService _categoryBlogService;
        private readonly IWebImageService _webImageService;

        public BlogController(IPostService postService,
            ICategoryBlogService categoryBlogService,
            IWebImageService webImageService)
        {
            _postService = postService;
            _categoryBlogService = categoryBlogService;
            _webImageService = webImageService;
        }

        [Route(BlogEndpoints.EnglishIndexEndpoint)]
        [Route(BlogEndpoints.EnglishIndexPagedEndpoint)]
        [Route(BlogEndpoints.EnglishCatPagedEndpoint)]
        [HttpGet]
        public IActionResult Index(int page = 1, string cat = "")
        {
            var model = _postService.GetPagedAll(page, 12, publishDate: true, lang: CurrentLang, cat: cat);
            ViewBag.cat = cat;
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbNews).FirstOrDefault()?.URLImage;
            return View(model);
        }

        [Route(BlogEndpoints.EnglishPostEndpoint)]
        public IActionResult Post(string slug)
        {
            var model = _postService.GetPostSlug(slug);
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbNews).FirstOrDefault()?.URLImage;
            return View(model);
        }
    }
}