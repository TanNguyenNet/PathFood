using CV.Data.Enum;
using CV.Service.Interface.Setting;
using CV.Utils.Helper;
using System.Collections.Generic;
using System.Linq;

namespace CV.Service.Setting
{
    public class LanguageService : ILanguageService
    {
        public IEnumerable<dynamic> Get()
        {
            var list = EnumHelper.ToDictionary(typeof(Languages)).Select(x => new { Id = x.Key, Name = x.Value });
            return list;
        }
    }
}