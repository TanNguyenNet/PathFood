using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Catalog
{
    public class ProductModel: AuditTableModel
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public string Color { set; get; }

        public string Slug { set; get; }

        public string CatalogFunctionId { set; get; }

        public string CatalogSectorId { set; get; }

        public virtual CatalogFunctionModel CatalogFunction { set; get; }

        public virtual CatalogSectorModel CatalogSector { set; get; }
    }
}
