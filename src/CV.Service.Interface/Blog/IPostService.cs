using CV.Data.Enum;
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

        PagedResult<PostModel> GetPagedAll(int page = 1, int pageSize = 20, string filter = ""
            , DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null, bool publishDate = false, Languages? lang = null,string cat ="", bool include = false);

        IEnumerable<PostModel> GetAll(Languages? lang = null, int totalPost = 1,
            bool home = false, bool? active = null, bool publishDate = false);

        PostModel Insert(string userCurrent, PostModel post);

        PostModel Update(string id, string userCurrentId, PostModel post);

        void Delete(string id, string userId);
    }
}
