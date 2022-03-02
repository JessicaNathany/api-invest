using Api.Invest.Data.Repository;
using Api.Invest.Service;
using Api.Invest.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Invest.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFundoRepository, FundoRepository>();
            services.AddScoped<ITesouroDiretoRepository, TesouroDiretoRepository>();
            services.AddScoped<IRendaFixaRepository, RendaFixaRepository>();
            services.AddScoped<IMeusInvestimentosService, MeusInvestimentosService>();
            services.AddScoped<ITesouroDiretoServices, TesouroDiretoServices>();
            services.AddScoped<IRendaFixaService, RendaFixaService>();
            services.AddScoped<IFundoService, FundoService>();
            services.AddScoped<IResgateService, ResgateService>();

            return services;
        }
    }
}
