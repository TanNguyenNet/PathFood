using CV.Data.Model.Blog;
using CV.Utils.Utils.Web.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Blog
{
    public interface IPostService
    {
        PostModel GetPost(string id);

        PostModel GetPostSlug(string slug);

        PagedResult<PostModel> GetAll(int page = 1, int pageSize = 20, string filter = ""
            , DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null);

        PostModel Insert(string userCurrent, PostModel post);

        PostModel Update(string id, string userCurrentId, PostModel post);

        void Delete(string id, string userId);
    }
}
