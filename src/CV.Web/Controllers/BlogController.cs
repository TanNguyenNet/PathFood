using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.Blog;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
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

        [Route(BlogEndpoints.IndexEndpoint)]
        [Route(BlogEndpoints.IndexPagedEndpoint)]
        [HttpGet]
        public IActionResult Index(int page = 1, string cat = "")
        {

            var pageModel = new PagePostModel();
            pageModel.Category = _categoryBlogService.GetAll(CurrentLang);

            var model = _postService.GetPagedAll(page, 3, publishDate: true, lang: CurrentLang, cat: cat);
            pageModel.MixPost = model.Results;

            foreach (var item in pageModel.Category)
            {
                var posts = _postService.GetPagedAll(page, 4, publishDate: true, lang: CurrentLang, cat: item.Slug);
                if (pageModel.Posts is null)
                    pageModel.Posts = posts.Results;
                else
                {
                    var tmp = pageModel.Posts.ToList();
                    foreach (var post in posts.Results)
                    {
                        tmp.Add(post);
                    }
                    pageModel.Posts = tmp;
                }
            }

            ViewBag.cat = cat;
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbNews).FirstOrDefault()?.URLImage;

            return View(pageModel);
        }

        [Route(BlogEndpoints.CatPagedEndpoint)]
        [HttpGet]
        public IActionResult PostCategory(int page = 1, string cat = "")
        {

            var pageModel = new PagePostModel();

            var model = _postService.GetPagedAll(page, 3, publishDate: true, lang: CurrentLang, cat: cat);
            pageModel.MixPost = model.Results;

            pageModel.PagePost = _postService.GetPagedAll(page, 12, publishDate: true, lang: CurrentLang, cat: cat);

            var category = _categoryBlogService.GetCategoryBlog("", cat);

            ViewBag.Title = category.Name;
            ViewBag.Description = category.Name + " - path";

            ViewBag.cat = cat;
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbNews).FirstOrDefault()?.URLImage;

            return View(pageModel);
        }

        [Route(BlogEndpoints.PostEndpoint)]
        public IActionResult Post(string slug)
        {
            var model = _postService.GetPostSlug(slug);
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbNews).FirstOrDefault()?.URLImage;
            return View(model);
        }
    }
}