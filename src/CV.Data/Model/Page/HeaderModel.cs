using CV.Data.Model.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Page
{
    public class HeaderModel
    {
        public IEnumerable<CatalogFunctionModel> CatalogFunctions { set; get; }

        public IEnumerable<CatalogSectorModel> CatalogSectors { set; get; }
    }
}
