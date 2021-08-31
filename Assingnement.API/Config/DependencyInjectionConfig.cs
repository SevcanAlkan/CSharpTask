using Assingnement.Core.Helper;
using Assingnement.Data;
using Assingnement.Data.Service;
using Assingnement.Data.SubStructure;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assingnement.API.Config
{
    internal static class DependencyInjectionConfig
    {
        internal static void Add(ref IServiceCollection services, IConfiguration configuration, ref IMapper mapper)
        {
            services.AddSingleton(mapper);
            services.AddDbContext<AssingnementDbContext>(db =>
                db.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Assingnement.Data")));
            services.AddScoped<UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IBaseService<,,,,>), typeof(BaseService<,,,,>));

            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IOwnerService, OwnerService>();

            services.AddSingleton<IConfiguration>(provider => configuration);

            services.AddTransient(typeof(APIResult));
            services.AddTransient(typeof(APIResult<>));

            services.AddTransient(typeof(DeliveryKingDbContextInitializer));
        }
    }
}
