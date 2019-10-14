using CV.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Setting
{
    public class WebImageModel:AuditTableModel
    {
        public string Name { set; get; }

        public string URL { set; get; }

        public string URLImage { set; get; }

        public Position Position { set; get; }
    }
}
