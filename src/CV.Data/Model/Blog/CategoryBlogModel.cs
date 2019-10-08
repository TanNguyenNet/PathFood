using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Blog
{
    public class CategoryBlogModel : AuditTableModel
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public string Slug { set; get; }

        public string UrlImage { set; get; }

        public bool SetHomePage { set; get; }

        public bool Active { set; get; }

        
    }
}
