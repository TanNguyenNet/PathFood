using CV.Data.Model.FAQ;
using CV.Service.Interface.FAQ;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.FAQ
{
    public class QuestionController : BaseApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 20, string filter = "")
        {
            var model = _questionService.GetPagedAll(page, pageSize, filter);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetQuestion(string id)
        {
            var model = _questionService.GetQuestion(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(QuestionModel questionModel)
        {
            if (ModelState.IsValid)
            {
                var newCat = _questionService.Insert(base.UserId, questionModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, QuestionModel questionModel)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _questionService.Update(id, base.UserId, questionModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _questionService.Delete(id, base.UserId);
            return Ok();
        }
    }
}