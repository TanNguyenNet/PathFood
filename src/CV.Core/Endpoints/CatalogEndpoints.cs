using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Core.Endpoints
{
    public class CatalogEndpoints
    {
        public const string IndexEndpoint = "~/sanpham";

        public const string SectorEndpoint = "~/nhom-sanpham-{sector}";

        public const string FunctionEndpoint = "~/nhom-chucnang-{function}";


        public const string EnglishIndexEndpoint = "~/en/sanpham";

        public const string EnglishSectorEndpoint = "~/en/nhom-sanpham-{sector}";

        public const string EnglishFunctionEndpoint = "~/en/nhom-chucnang-{function}";
    }
}
