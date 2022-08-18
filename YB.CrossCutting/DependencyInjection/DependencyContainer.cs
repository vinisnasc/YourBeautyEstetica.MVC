using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YB.Data;
using YB.Data.Repository;
using YB.Domain.Interfaces.Repository;
using YB.Domain.Interfaces.Services;
using YB.Domain.Notificacoes;
using YB.Services;

namespace YB.CrossCutting.DependencyInjection
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Context
            services.AddDbContext<YBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("YBContext"));
            });

            // Services
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<INotificador, Notificador>();

            // Repositorios
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}