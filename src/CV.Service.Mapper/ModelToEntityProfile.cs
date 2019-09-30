using AutoMapper;
using CV.Data.Entities.Blog;
using CV.Data.Model.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Mapper
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<PostModel, Post>();

            CreateMap<CategoryBlogModel, CategoryBlog>();
        }
    }
}
