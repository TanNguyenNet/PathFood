using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CV.Core.Authorization;
using CV.Core.Data;
using CV.Data.EF;
using CV.Data.EF.Repository;
using CV.Data.Entities.Identity;
using CV.Service;
using CV.Service.Identity;
using CV.Service.Interface;
using CV.Service.Interface.Identity;
using CV.Service.Mapper;
using CV.Utils.Contants;
using CV.Utils.Utils.Config;
using CV.Web.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CV.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            IConfigurationRoot connectionConfig = new ConfigurationBuilder()
                .AddJsonFile(CV.Utils.Contants.ConfigurationFileName.ConnectionConfig, false, true).Build();

            var connectionString = connectionConfig.GetValueByEnv<string>(ConfigurationSectionName.ConnectionStrings);

            services.AddDbContext<CVContext>(opt => opt.UseSqlServer(connectionString, o => o.MigrationsAssembly("CV.Data.EF")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<CVContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(
                options =>
                {
                    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddConfigureCookieSettings();

            services.AddAutoMapperSetup();
            
            services.AddConfigIdentityOption();

            services.AddAuthorizationPolicySetup();

            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient<IBootstrapper, Bootstrapper>();

            services.AddTransient<IBootstrapperService, BootstrapperService>();

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddTransient<IUserIdentityService, UserIdentityService>();

            services.AddTransient<IPolicyService, PolicyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "admin",
                    template: "admin/{controller=Login}/{action=Index}/{id?}");

                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "default",
                    areaName: "admin",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Dashboard", action = "Index" });
            });
        }
    }
}
