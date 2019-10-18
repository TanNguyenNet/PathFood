using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Service.Interface.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ICategoryBlogService _categoryBlogService;

        public BlogController(IPostService postService, ICategoryBlogService categoryBlogService)
        {
            _postService = postService;
            _categoryBlogService = categoryBlogService;
        }

        [Route(BlogEndpoints.IndexEndpoint)]
        [Route(BlogEndpoints.IndexPagedEndpoint)]
        [Route(BlogEndpoints.CatPagedEndpoint)]
        [HttpGet]
        public IActionResult Index(int page = 1, string cat = "")
        {
            var model = _postService.GetPagedAll(page, 12, publishDate: true, lang: CurrentLang, cat: cat);
            ViewBag.cat = cat;
            return View(model);
        }

        [Route(BlogEndpoints.PostEndpoint)]
        public IActionResult Post(string slug)
        {
            var model = _postService.GetPostSlug(slug);
            return View(model);
        }
    }
}