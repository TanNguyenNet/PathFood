using CV.Service;
using CV.Service.Blog;
using CV.Service.Catalog;
using CV.Service.FAQ;
using CV.Service.Identity;
using CV.Service.Interface;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Catalog;
using CV.Service.Interface.FAQ;
using CV.Service.Interface.Identity;
using CV.Service.Interface.Setting;
using CV.Service.Setting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Extension
{
    public static class ApplicationServiceSetup
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<IBootstrapperService, BootstrapperService>();

            services.AddTransient<IUserIdentityService, UserIdentityService>();

            services.AddTransient<IPolicyService, PolicyService>();

            services.AddTransient<ICategoryBlogService, CategoryBlogService>();

            services.AddTransient<IPostService, PostService>();

            services.AddTransient<IPageContentService, PageContentService>();

            services.AddTransient<ILanguageService, LanguageService>();

            services.AddTransient<ICatalogFunctionService, CatalogFunctionService>();

            services.AddTransient<ICatalogSectorService, CatalogSectorService>();

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IGroupQuestionService, GroupQuestionService>();

            services.AddTransient<IQuestionService, QuestionService>();

            services.AddTransient<IWebImageService, WebImageService>();

            services.AddTransient<IInfoService, InfoService>();

        }
    }
}
