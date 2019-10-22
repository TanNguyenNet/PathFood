using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.Setting;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IEmailService _emailService;
        private readonly IInfoService _infoService;

        public ContactController(IEmailService emailService, IInfoService infoService)
        {
            _emailService = emailService;
            _infoService = infoService;
        }

        [Route(ContactEndpoints.IndexEndpoint)]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _infoService.GetAll(Data.Enum.InfoType.InfoCompay);
            return View(model);
        }

        [Route(ContactEndpoints.SendContactEndPoint)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendContact(EmailSenderModel emailSenderModel)
        {
            emailSenderModel.Message = "Tên liên hệ: " + emailSenderModel.FullName +
                " Email liên hệ: " + emailSenderModel.Email +
                " Điện thoại liên hệ: " + emailSenderModel.Phone +
                "\n\n" + emailSenderModel.Message;
            _emailService.SendMailSMTP(emailSenderModel);
            return RedirectToAction("Index");
        }
    }
}