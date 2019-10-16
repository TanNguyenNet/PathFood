using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Blog
{
    public class PageContentModel : AuditTableModel
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public string Content { set; get; }

        public string URLImage { set; get; }
    }
}
