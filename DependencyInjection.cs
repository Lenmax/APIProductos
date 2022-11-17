using APIProductos.Data;
using APIProductos.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIProductos
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped <IProductoRepository, ProductoRepository>();


            return services;
        }
    }
}
