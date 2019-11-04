using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Setting
{
    public class SearchPageModel : BaseEntityModel
    {
        public string Name { set; get; }

        public string Slug { set; get; }

        public string URL { set; get; }

        public string ItemId { set; get; }
    }
}
