using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarefa.Infrastructure.DataBase;

namespace Tarefa.Infrastructure.DataBase
{
    public static class Setup
    {
        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
               options.UseSqlite("Data Source=tarefa.db"));
        }
    }
}
