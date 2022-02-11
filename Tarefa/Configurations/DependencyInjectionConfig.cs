using Microsoft.Extensions.DependencyInjection;
using Tarefa.Data;
using Tarefa.Data.Repository;
using Tarefa.Data.Repository.Interfaces;

namespace Tarefa.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
