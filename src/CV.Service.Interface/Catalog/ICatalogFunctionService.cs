using CV.Data.Enum;
using CV.Data.Model.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Catalog
{
    public interface ICatalogFunctionService
    {
        CatalogFunctionModel GetCatalogFunction(string id);

        IEnumerable<CatalogSectorModel> GetAll(Languages? lang);

        CatalogSectorModel Insert(string userCurrentId, CatalogSectorModel catalogFunction);

        CatalogSectorModel Update(string catId, string userCurrentId, CatalogSectorModel catalogFunction);

        void Delete(string id, string userId);
    }
}
