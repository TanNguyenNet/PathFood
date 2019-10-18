using CV.Data.Entities.Blog;
using CV.Data.Model.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Blog
{
    public interface IPageContentService
    {
        IEnumerable<PageContentModel> GetAll(bool? home = null);

        PageContentModel GetPage(string id);

        PageContentModel GetPageSlug(string slug);

        PageContentModel Insert(string userCurrent, PageContentModel pageContent);

        PageContentModel Update(string userCurrent, string pageId, PageContentModel pageContent);

        void Delete(string userCurrent, string pageId);
    }
}
