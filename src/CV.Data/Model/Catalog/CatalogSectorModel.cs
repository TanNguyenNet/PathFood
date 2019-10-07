using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Catalog
{
    public class CatalogSectorModel : AuditTableModel
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public string Color { set; get; }

        public string URLImage { set; get; }

        public string Slug { set; get; }

        public ICollection<ProductModel> Product { set; get; }
    }
}
