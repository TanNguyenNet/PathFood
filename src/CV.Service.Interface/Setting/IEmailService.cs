using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Setting
{
    public interface IEmailService
    {
        bool SendMailSMTP(EmailSenderModel emailSenderModel);
    }
}
