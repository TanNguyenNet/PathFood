using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Core.Endpoints
{
    public class BlogEndpoints
    {
        public const string IndexEndpoint = "~/tintuc";
        public const string IndexPagedEndpoint = "~/tintuc-{page}";
        public const string CatPagedEndpoint = "~/nhomtintuc-{page}-{cat}";

        public const string PostEndpoint = "~/tintuc/{slug}";
    }
}
