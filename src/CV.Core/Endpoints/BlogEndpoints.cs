using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Core.Endpoints
{
    public class BlogEndpoints
    {
        public const string IndexEndpoint = "~/tintuc";
        public const string IndexPagedEndpoint = "~/tintuc-{page}";
        public const string CatPagedEndpoint = "~/nhomtintuc-{page}/{cat}";

        public const string PostEndpoint = "~/tintuc/{slug}";


        public const string EnglishIndexEndpoint = "~/en/tintuc";
        public const string EnglishIndexPagedEndpoint = "~/en/tintuc-{page}";
        public const string EnglishCatPagedEndpoint = "~/en/nhomtintuc-{page}/{cat}";

        public const string EnglishPostEndpoint = "~/en/tintuc/{slug}";

    }
}
