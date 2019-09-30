using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.Blog
{
    public class Post:AuditTable
    {
        public Post()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get; }

        public string Content { set; get; }

        public string Description { set; get; }

        public string UrlImage { set; get; }

        public DateTimeOffset? PushlishDate { set; get; }

        public bool SetHomePage { set; get; } = false;

        public bool Active { set; get; } = true;
    }
}
