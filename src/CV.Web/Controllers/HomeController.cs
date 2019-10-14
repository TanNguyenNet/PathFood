using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.Page;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostService _postService;
        private readonly IWebImageService _webImageService;

        public HomeController(IPostService postService, IWebImageService webImageService)
        {
            _postService = postService;
            _webImageService = webImageService;
        }

        [Route(HomeEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeModel();
            model.Images = _webImageService.GetAll(Data.Enum.Position.HomeSlide);
            model.Posts = _postService.GetAll(CurrentLang, 4, active: true, publishDate: true);
            model.PostsHot = _postService.GetAll(CurrentLang, 2, true, active: true, publishDate: true);
            return View(model);
        }


    }
}