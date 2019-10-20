using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Model.Setting;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Settings
{
    public class InfoController : BaseApiController
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet]
        public IActionResult GetAllType()
        {
            var model = _infoService.GetAllType();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _infoService.GetAll();
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetInfo(string id)
        {
            var model = _infoService.GetInfo(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(InfoModel model)
        {
            if (ModelState.IsValid)
            {
                var newCat = _infoService.Insert(base.UserId, model);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, InfoModel model)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _infoService.Update(base.UserId, id, model);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _infoService.Delete(base.UserId, id);
            return Ok();
        }

    }
}