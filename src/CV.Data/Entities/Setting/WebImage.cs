using CV.Data.Enum;
using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.Setting
{
    public class WebImage: AuditTable
    {
        public WebImage()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get; }

        public string URL { set; get; }

        public string URLImage { set; get; }

        public Position Position { set; get; }
    }
}
