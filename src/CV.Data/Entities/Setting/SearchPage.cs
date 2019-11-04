using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.Setting
{
    public class SearchPage : BaseEntity
    {
        public SearchPage()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get; }

        public string Slug { set; get; }

        public string URL { set; get; }

        public string ItemId { set; get; }
    }
}
