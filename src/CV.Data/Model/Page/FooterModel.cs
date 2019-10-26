using CV.Data.Model.Blog;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Page
{
    public class FooterModel
    {
        public IEnumerable<InfoModel> Infos { set; get; }

        public IEnumerable<PageContentModel> PageContents { set; get; }
    }
}
