using CV.Data.Enum;
using CV.Data.Model.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Blog
{
    public interface ICategoryBlogService
    {
        CategoryBlogModel GetCategoryBlog(string id,string slug="");

        IEnumerable<CategoryBlogModel> GetAll(Languages? lang);

        CategoryBlogModel Insert(string userCurrentId, CategoryBlogModel category);

        CategoryBlogModel Update(string catId, string userCurrentId, CategoryBlogModel category);

        void Delete(string id,string userId);
    }
}
