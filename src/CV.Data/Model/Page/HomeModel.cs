using CV.Data.Model.Blog;
using CV.Data.Model.Catalog;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Page
{
    public class HomeModel
    {
        public IEnumerable<PostModel> Posts { set; get; }

        public IEnumerable<PostModel> PostsHot { set; get; }

        public IEnumerable<WebImageModel> Images { set; get; }

        public IEnumerable<CatalogFunctionModel> CatalogFunctions { set; get; }

        public IEnumerable<CatalogSectorModel> CatalogSectors { set; get; }

        public IEnumerable<WebImageModel> Logos { set; get; }

    }
}
