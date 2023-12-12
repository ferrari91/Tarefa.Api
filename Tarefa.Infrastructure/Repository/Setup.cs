using Microsoft.Extensions.DependencyInjection;
using Tarefa.Application.Interface;
using Tarefa.Application.Interface.Repositories;

namespace Tarefa.Infrastructure.Repository
{
    public static class Setup
    {
        public static void ConfigureResporitories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<ITaskRepository, TaskRepository>();

            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
    }
}
