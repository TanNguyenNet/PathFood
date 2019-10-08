using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Model.FAQ;
using CV.Service.Interface.FAQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.FAQ
{
    public class GroupQuestionController : BaseApiController
    {
        private readonly IGroupQuestionService _groupQuestionService;

        public GroupQuestionController(IGroupQuestionService groupQuestionService)
        {
            _groupQuestionService = groupQuestionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _groupQuestionService.GetAll(null);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGroupQuestion(string id)
        {
            var model = _groupQuestionService.GetGroupQuestion(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(GroupQuestionModel groupQuestionModel)
        {
            if (ModelState.IsValid)
            {
                var newCat = _groupQuestionService.Insert(base.UserId, groupQuestionModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, GroupQuestionModel groupQuestionModel)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _groupQuestionService.Update(id, base.UserId, groupQuestionModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _groupQuestionService.Delete(id, base.UserId);
            return Ok();
        }
    }
}