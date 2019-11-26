using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Blog
{
    public class PagePostModel
    {

        public IEnumerable<PostModel> MixPost { set; get; }

        public IEnumerable<CategoryBlogModel> Category { set; get; }

        public IEnumerable<PostModel> Posts { set; get; }

        
    }
}
