using CV.Data.Enum;
using CV.Data.Model.Blog;
using CV.Service.Interface.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Blog
{
    public class PostController : BaseApiController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Get(int page = 1, int pageSize = 20, string filter = "", Languages? lang = null)
        {
            var model = _postService.GetPagedAll(page, pageSize, filter, include: true, lang: lang);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPost(string id)
        {
            var model = _postService.GetPost(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                var newPost = _postService.Insert(base.UserId, postModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                var updatePost = _postService.Update(id, base.UserId, postModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _postService.Delete(id, base.UserId);
            return Ok();
        }
    }
}