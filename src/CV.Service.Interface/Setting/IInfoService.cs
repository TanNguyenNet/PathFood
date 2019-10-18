using CV.Data.Enum;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Setting
{
    public interface IInfoService
    {
        IEnumerable<InfoModel> GetAll();

        InfoModel GetInfo(string id);

        IEnumerable<InfoModel> InfoType(InfoType type);

        IEnumerable<dynamic> GetAllPosition();

        InfoModel Insert(string userCurrent, InfoModel info);

        InfoModel Update(string userCurrent, string infoId, InfoModel info);

        void Delete(string userCurrent, string infoId);
    }
}
