﻿using CV.Data.Enum;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Setting
{
    public interface IWebImageService
    {
        IEnumerable<WebImageModel> GetAll(Position? position = null);

        WebImageModel GetImage(string id);

        IEnumerable<dynamic> GetAllPosition();

        WebImageModel Insert(string userCurrent, WebImageModel webImage);

        WebImageModel Update(string userCurrent, string imageId, WebImageModel webImage);

        void Delete(string userCurrent, string imageId);
    }
}
