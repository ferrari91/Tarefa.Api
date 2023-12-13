using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Entities;
using Tarefa.Infrastructure.DataBase;

namespace Tarefa.Infrastructure.Repository
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
