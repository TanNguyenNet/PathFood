using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Service.Interface.FAQ;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;
        private readonly IGroupQuestionService _groupQuestionService;

        public QuestionController(IQuestionService questionService,IGroupQuestionService groupQuestionService)
        {
            _questionService = questionService;
            _groupQuestionService = groupQuestionService;
        }

        [Route(QuestionEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _groupQuestionService.GetAll(lang: base.CurrentLang);
            return View(model);
        }
    }
}