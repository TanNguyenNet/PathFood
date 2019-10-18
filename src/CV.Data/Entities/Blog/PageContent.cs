using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.Blog
{
    public class PageContent : AuditTable
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public string Content { set; get; }

        public string URLImage { set; get; }

        public string Slug { set; get; }

        public bool Home { set; get; }
    }
}
