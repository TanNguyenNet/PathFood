using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.Page;
using CV.Service.Interface.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        [Route(HomeEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeModel();

            model.Posts = _postService.GetAll(CurrentLang, 4, active: true, publishDate: true);
            model.PostsHot = _postService.GetAll(CurrentLang, 2, true, active: true, publishDate: true);
            return View(model);
        }


    }
}