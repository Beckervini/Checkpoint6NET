using CP3.Data.AppData;
using CP3.Data.Repositories;
using CP3.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CP3.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do contexto do banco de dados
            services.AddDbContext<ApplicationContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:DefaultConnection"]); 

            // Injeção de dependência para repositórios e serviços
            services.AddScoped<IBarcoRepository, BarcoRepository>();
            services.AddScoped<IBarcoApplicationService, BarcoApplicationService>();
        }
    }
}
