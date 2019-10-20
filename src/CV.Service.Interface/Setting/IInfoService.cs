using CV.Data.Enum;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Setting
{
    public interface IInfoService
    {
        InfoModel GetInfo(string id);

        IEnumerable<InfoModel> GetAll(InfoType? type=null);

        IEnumerable<dynamic> GetAllType();

        InfoModel Insert(string userCurrent, InfoModel info);

        InfoModel Update(string userCurrent, string infoId, InfoModel info);

        void Delete(string userCurrent, string infoId);
    }
}
