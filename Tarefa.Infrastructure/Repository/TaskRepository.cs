using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Model;
using Tarefa.Infrastructure.DataBase;

namespace Tarefa.Infrastructure.Repository
{
    public class TaskRepository : BaseRepository<TaskModel>, ITaskRepository
    {
        public TaskRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
