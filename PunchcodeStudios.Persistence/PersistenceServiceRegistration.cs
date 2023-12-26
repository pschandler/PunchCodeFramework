using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Persistence.DatabaseContext;
using PunchcodeStudios.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Persistence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PCStudioDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PCStudioConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IGalleryTypeRepository, GalleryTypeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryGalleryRepository, CategoryGalleryRepository>();

            return services;
        }
    }
}
