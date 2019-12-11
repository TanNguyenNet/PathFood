using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.Setting;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.WebEnglish.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IEmailService _emailService;
        private readonly IInfoService _infoService;
        private readonly IWebImageService _webImageService;

        public ContactController(IEmailService emailService, IInfoService infoService, IWebImageService webImageService)
        {
            _emailService = emailService;
            _infoService = infoService;
            _webImageService = webImageService;
        }

        [Route(ContactEndpoints.EnIndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _infoService.GetAll(Data.Enum.InfoType.InfoCompay);
            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbContact).FirstOrDefault()?.URLImage;
            return View(model);
        }

        [Route(ContactEndpoints.EnSendContactEndPoint)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendContact(EmailSenderModel emailSenderModel)
        {
            emailSenderModel.Message = "Name: " + emailSenderModel.FullName +
                " Email contact: " + emailSenderModel.Email +
                " Phone contact: " + emailSenderModel.Phone +
                "\n\n" + emailSenderModel.Message;
            _emailService.SendMailSMTP(emailSenderModel);
            return RedirectToAction("Index");
        }
    }
}