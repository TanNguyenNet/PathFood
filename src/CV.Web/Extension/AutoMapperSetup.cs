using AutoMapper;
using CV.Service.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Extension
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(typeof(AutoMapperSetup));

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
             
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper().ConfigurationProvider);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
        }
    }
}
