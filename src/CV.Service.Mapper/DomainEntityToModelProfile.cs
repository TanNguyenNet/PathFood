using AutoMapper;
using CV.Data.Entities.Blog;
using CV.Data.Entities.Identity;
using CV.Data.Model.Blog;
using CV.Data.Model.Identity;
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
        }
    }
}
