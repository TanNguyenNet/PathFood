using CV.Data.Enum;
using CV.Data.Model.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Catalog
{
    public interface ICatalogSectorService
    {
        CatalogSectorModel GetCatalogSector(string id);

        IEnumerable<CatalogSectorModel> GetAll(Languages? lang, bool active = false);

        CatalogSectorModel Insert(string userCurrentId, CatalogSectorModel catalogSector);

        CatalogSectorModel Update(string catId, string userCurrentId, CatalogSectorModel catalogSector);

        void Delete(string id, string userId);
    }
}
