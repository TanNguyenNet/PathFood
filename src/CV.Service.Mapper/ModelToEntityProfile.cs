using AutoMapper;
using CV.Data.Entities.Blog;
using CV.Data.Entities.Catalog;
using CV.Data.Entities.FAQ;
using CV.Data.Entities.Setting;
using CV.Data.Model.Blog;
using CV.Data.Model.Catalog;
using CV.Data.Model.FAQ;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Mapper
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<PostModel, Post>();

            CreateMap<CategoryBlogModel, CategoryBlog>();

            CreateMap<QuestionModel, Question>();

            CreateMap<GroupQuestionModel, GroupQuestion>().MaxDepth(2);

            CreateMap<ProductModel, Product>();

            CreateMap<CatalogFunctionModel, CatalogFunction>();

            CreateMap<CatalogSectorModel, CatalogSector>();

            CreateMap<WebImageModel, WebImage>();

            CreateMap<PageContentModel, PageContent>();

            CreateMap<InfoModel, Info>();

            CreateMap<SearchPageModel, SearchPage>();
        }
    }
}
