using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Blog
{
    public class PostModel: AuditTableModel
    {
        public string Name { set; get; }

        public string Content { set; get; }

        public string Description { set; get; }

        public string Slug { set; get; }

        public string UrlImage { set; get; }

        public DateTimeOffset? PushlishDate { set; get; }

        public bool SetHomePage { set; get; }

        public bool Active { set; get; }

        public string CategoryBlogId { set; get; }

        public virtual CategoryBlogModel CategoryBlog { set; get; }
    }
}
