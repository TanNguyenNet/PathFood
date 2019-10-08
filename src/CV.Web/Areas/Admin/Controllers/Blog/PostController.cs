using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.Admin.Controllers.Blog
{
    public class PostController : BaseController
    {
        public PostController()
        {
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(string id)
        {
            ViewBag.postId = id;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}