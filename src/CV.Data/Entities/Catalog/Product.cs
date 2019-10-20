using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.Catalog
{
    public class Product : AuditTable
    {
        public Product()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get;}

        public string Description { set; get; }

        public string Color { set; get; }

        public string UrlImage { set; get; }

        public string Slug { set; get; }

        public bool Active { set; get; }

        public bool New { set; get; }

        public string CatalogFunctionId { set; get; }

        public string CatalogSectorId { set; get; }

        public virtual CatalogFunction CatalogFunction { set; get; }

        public virtual CatalogSector CatalogSector { set; get; }

        
    }
}
