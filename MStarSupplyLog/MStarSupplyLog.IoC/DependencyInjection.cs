using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MStarSupplyLog.Application.Interfaces;
using MStarSupplyLog.Application.Mappings;
using MStarSupplyLog.Application.Services;
using MStarSupplyLog.Domain.Interfaces;
using MStarSupplyLog.Infra.Data.Context;
using MStarSupplyLog.Infra.Data.Repositories;

namespace MStarSupplyLog.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<ITipoMercadoriaRepository, TipoMercadoriaRepository>();
            services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
            services.AddScoped<IEntradaRepository, EntradaRepository>();
            services.AddScoped<ISaidaRepository, SaidaRepository>();

            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<ITipoMercadoriaService, TipoMercadoriaService>();
            services.AddScoped<IMercadoriaService, MercadoriaService>();
            services.AddScoped<IEntradaService, EntradaService>();
            services.AddScoped<ISaidaService, SaidaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        } 
    }
}
