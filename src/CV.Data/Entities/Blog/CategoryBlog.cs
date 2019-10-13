using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.Blog
{
    public class CategoryBlog: AuditTable
    {
        public CategoryBlog()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Slug { set; get; }

        public string UrlImage { set; get; }

        public bool SetHomePage { set; get; } = false;

        public bool Active { set; get; } = true;

        public virtual ICollection<Post> Post { set; get; }
    }
}
