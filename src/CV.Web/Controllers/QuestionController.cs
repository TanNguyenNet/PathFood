using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.FAQ;
using CV.Service.Interface.FAQ;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;
        private readonly IGroupQuestionService _groupQuestionService;
        private readonly IWebImageService _webImageService;

        public QuestionController(IQuestionService questionService, 
            IGroupQuestionService groupQuestionService,
            IWebImageService webImageService)
        {
            _questionService = questionService;
            _groupQuestionService = groupQuestionService;
            _webImageService = webImageService;
        }

        [Route(QuestionEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _groupQuestionService.GetAll(lang: base.CurrentLang);
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbFAQ).FirstOrDefault()?.URLImage;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendQuestion(QuestionModel question)
        {
            _questionService.Insert(question.CreatedBy, question);
            return RedirectToAction("Index");
        }
    }
}