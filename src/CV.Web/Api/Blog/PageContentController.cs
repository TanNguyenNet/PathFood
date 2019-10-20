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
    public class PageContentController : BaseApiController
    {

        private readonly IPageContentService _pageContentService;

        public PageContentController(IPageContentService pageContentService)
        {
            _pageContentService = pageContentService;
        }

        [HttpGet]
        public IActionResult Get(string filter = "")
        {
            var model = _pageContentService.GetAll(null);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPage(string id)
        {
            var model = _pageContentService.GetPage(id);
            return Ok(model);
        }


        [HttpPost]
        public IActionResult Create(PageContentModel pageModel)
        {
            if (ModelState.IsValid)
            {
                var newCat = _pageContentService.Insert(base.UserId, pageModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, PageContentModel pageModel)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _pageContentService.Update(base.UserId, id, pageModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _pageContentService.Delete(base.UserId, id);
            return Ok();
        }
    }
}