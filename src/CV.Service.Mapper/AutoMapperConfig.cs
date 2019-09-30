using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainEntityToModelProfile());

                cfg.AddProfile(new ModelToEntityProfile());
            });
        }
    }
}
