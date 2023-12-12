using Microsoft.Extensions.DependencyInjection;
using Tarefa.Application.Interface.Repositories;

namespace Tarefa.Infrastructure.Repository
{
    public static class Setup
    {
        public static void ConfigureResporitories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
