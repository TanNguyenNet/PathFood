﻿using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.Catalog
{
    public class CatalogSector : AuditTable
    {
        public CatalogSector()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Color { set; get; }

        public string URLImage { set; get; }

        public string Slug { set; get; }

        public bool Active { set; get; }

        public virtual ICollection<Product> Product { set; get; }

    }
}
