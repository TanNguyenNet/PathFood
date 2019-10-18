using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Model.Setting;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Settings
{
    public class WebImageController : BaseApiController
    {
        private readonly IWebImageService _webImageService;

        public WebImageController(IWebImageService webImageService)
        {
            _webImageService = webImageService;
        }

        [HttpGet]
        public IActionResult GetPosition()
        {
            var model = _webImageService.GetAllPosition();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _webImageService.GetAll();
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetImage(string id)
        {
            var model = _webImageService.GetImage(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(WebImageModel model)
        {
            if (ModelState.IsValid)
            {
                var newCat = _webImageService.Insert(base.UserId, model);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, WebImageModel model)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _webImageService.Update(base.UserId, id, model);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _webImageService.Delete(base.UserId, id);
            return Ok();
        }
    }
}