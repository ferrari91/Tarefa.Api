using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarefa.Application.Interface;
using Tarefa.Infrastructure.Services;

namespace Tarefa.Infrastructure.DataBase
{
    public static class Setup
    {
        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            services.AddDbContext<DataContext>(options =>
               options.UseSqlite($"Data Source={path}\\tarefa.db"));

            services.AddScoped<IDataService, DataService>();
        }
    }
}
