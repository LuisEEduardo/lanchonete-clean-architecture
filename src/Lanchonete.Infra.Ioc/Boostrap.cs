using Lanchonete.Application.App;
using Lanchonete.Application.Interface;
using Lanchonete.Application.Mapper;
using Lanchonete.Domain;
using Lanchonete.Domain.Interfaces;
using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Infra.Data.Context;
using Lanchonete.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lanchonete.Infra.Ioc
{
    public static class Boostrap
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddScoped<INotifier, Notifier>();

            services.AddScoped<ILancheRepository, LancheRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<ILancheApplication, LancheApplication>();

            return services;
        }
    }
}