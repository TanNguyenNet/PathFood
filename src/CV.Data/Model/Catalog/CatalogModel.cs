using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Catalog
{
    public class CatalogModel
    {
        public string Title { set; get; }

        public string UrlImage { set; get; }

        public IEnumerable<CatalogFunctionModel> CatalogFunctions { set; get; }

        public IEnumerable<CatalogSectorModel> CatalogSectors { set; get; }

        public IEnumerable<ProductModel> Products { set; get; }
    }
}
