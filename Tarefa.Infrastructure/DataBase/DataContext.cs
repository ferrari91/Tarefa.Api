using Microsoft.EntityFrameworkCore;
using Tarefa.Application.Interface.DataBase;
using Tarefa.Domain.Model;

namespace Tarefa.Infrastructure.DataBase
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<TaskModel> DbTask { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public async Task<bool> CreateDataBaseAsync() => await Database.EnsureCreatedAsync();
    }
}
