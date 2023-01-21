using Lanchonete.Application.App;
using Lanchonete.Application.Interface;
using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lanchonete.Infra.Ioc
{
    public class Boostrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ILancheRepository, LancheRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();


            services.AddScoped<ILancheApplication, LancheApplication>();
        }
    }
}