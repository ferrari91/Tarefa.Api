using Microsoft.EntityFrameworkCore;
using Tarefa.Domain.Model;

namespace Tarefa.Infrastructure.DataBase
{
    public class DataConfiguration<T> where T : BaseEntity
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>().Property(entity => entity.Id).IsRequired()
                         .ValueGeneratedOnAdd();

            modelBuilder.Entity<T>().HasIndex(entity => entity.Id).IsUnique();
        }
    }
}
