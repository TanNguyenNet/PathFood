using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Core.Endpoints
{
    public class BlogEndpoints
    {
        public const string IndexEndpoint = "~/tintuc";
        public const string IndexPagedEndpoint = "~/tintuc-{page}";

        public const string CatBlogEndpoint = "~/tintuc-{cat}";
        public const string CatBlogPagedEndpoint = "~/tintuc-{cat}-{page}";

        public const string PostEndpoint = "~/tintuc/{slug}";
    }
}
