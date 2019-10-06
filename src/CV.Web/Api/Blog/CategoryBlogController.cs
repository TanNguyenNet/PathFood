using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Model.Blog;
using CV.Service.Interface.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Blog
{

    public class CategoryBlogController : BaseApiController
    {
        private readonly ICategoryBlogService _categoryBlogService;
        public CategoryBlogController(ICategoryBlogService categoryBlogService)
        {
            _categoryBlogService = categoryBlogService;
        }

        [HttpGet]
        public IActionResult Get(string filter = "")
        {
            var model = _categoryBlogService.GetAll(null);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(Policy = nameof(ContantPolicy.User.ReadUserData))]
        public IActionResult GetCategory(string id)
        {
            var model = _categoryBlogService.GetCategoryBlog(id);
            return Ok(model);
        }


        [HttpPost]
        public IActionResult Create(CategoryBlogModel catModel)
        {
            if (ModelState.IsValid)
            {
                var newCat = _categoryBlogService.Insert(base.UserId, catModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, CategoryBlogModel catModel)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _categoryBlogService.Update(id, base.UserId, catModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _categoryBlogService.Delete(id, base.UserId);
            return Ok();
        }
    }
}