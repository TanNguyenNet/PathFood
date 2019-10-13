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

        IEnumerable<CatalogFunctionModel> GetAll(Languages? lang, bool active = false);

        CatalogFunctionModel Insert(string userCurrentId, CatalogFunctionModel catalogFunction);

        CatalogFunctionModel Update(string catId, string userCurrentId, CatalogFunctionModel catalogFunction);

        void Delete(string id, string userId);
    }
}
