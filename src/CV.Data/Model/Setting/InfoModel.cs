﻿using CV.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Setting
{
    public class InfoModel: AuditTableModel
    {
        public string Name { set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Hotline { set; get; }

        public string Email { set; get; }

        public string Fax { set; get; }

        public string Zalo { set; get; }

        public string Password { set; get; }

        public string PortEmail { set; get; }

        public string SmtpEmail { set; get; }

        public InfoType InfoType { set; get; }
    }
}