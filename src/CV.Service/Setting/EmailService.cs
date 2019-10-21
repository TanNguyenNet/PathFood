using AutoMapper;
using CV.Core.Data;
using CV.Data.Entities.Setting;
using CV.Data.Model.Setting;
using CV.Service.Interface.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CV.Service.Setting
{
    public class EmailService : IEmailService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Info> _infoRepo;
        private readonly IUnitOfWork _uow;

        public EmailService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _infoRepo = _uow.GetRepository<Info>();
        }

        public bool SendMailSMTP(EmailSenderModel emailSenderModel)
        {
            try
            {
                var infoMail = _infoRepo.TableNoTracking.Where(x => x.InfoType == Data.Enum.InfoType.Email).FirstOrDefault();


                SmtpClient client = new SmtpClient(infoMail.SmtpEmail);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(infoMail.Email, infoMail.Password);
                client.Port = int.Parse(infoMail.PortEmail);

                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress(infoMail.Email);
                mailmsg.To.Add(emailSenderModel.Email);
                mailmsg.Body = emailSenderModel.Message;
                mailmsg.Subject = emailSenderModel.Subject;

                client.Send(mailmsg);
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
