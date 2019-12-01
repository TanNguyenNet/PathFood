using CV.Data.Enum;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Setting
{
    public interface ISearchService
    {
        IEnumerable<SearchPageModel> GetAll(string filter, Languages? lang);
    }
}
