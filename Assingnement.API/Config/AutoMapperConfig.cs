using Assingnement.Data;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assingnement.API.Config
{
    internal static class AutoMapperConfig
    {
        internal static IMapper Add(ref IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainMappingConfiguration());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddAutoMapper(typeof(Startup).Assembly);

            return mapper;
        }
    }
}
