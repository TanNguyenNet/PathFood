using AutoMapper;
using CV.Data.Entities.Blog;
using CV.Data.Entities.Catalog;
using CV.Data.Entities.FAQ;
using CV.Data.Entities.Identity;
using CV.Data.Entities.Setting;
using CV.Data.Model.Blog;
using CV.Data.Model.Catalog;
using CV.Data.Model.FAQ;
using CV.Data.Model.Identity;
using CV.Data.Model.Setting;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CV.Service.Mapper
{
    public class DomainEntityToModelProfile : Profile
    {
        public DomainEntityToModelProfile()
        {
            CreateMap<AppUser, AppUserModel>();

            CreateMap<Claim, ClaimRequirementModel>()
                .ForMember(d => d.ClaimName, s => s.MapFrom(x => x.Type))
                .ForMember(d => d.ClaimValue, s => s.MapFrom(x => x.Value));

            CreateMap<Post, PostModel>();

            CreateMap<CategoryBlog, CategoryBlogModel>();

            CreateMap<Question, QuestionModel>();

            CreateMap<GroupQuestion, GroupQuestionModel>().MaxDepth(2);

            CreateMap<Product, ProductModel>();

            CreateMap<CatalogFunction, CatalogFunctionModel>().MaxDepth(2);

            CreateMap<CatalogSector, CatalogSectorModel>().MaxDepth(2);

            CreateMap<WebImage, WebImageModel>();

            CreateMap<Info, InfoModel>();

            CreateMap<PageContent, PageContentModel>();

            CreateMap<SearchPage, SearchPageModel>();
        }
    }
}
