using CV.Service;
using CV.Service.Blog;
using CV.Service.Identity;
using CV.Service.Interface;
using CV.Service.Interface.Blog;
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

            services.AddTransient<ILanguageService, LanguageService>();

        }
    }
}
