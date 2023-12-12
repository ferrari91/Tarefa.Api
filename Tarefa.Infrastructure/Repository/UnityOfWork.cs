using Tarefa.Application.Interface;
using Tarefa.Infrastructure.DataBase;

namespace Tarefa.Infrastructure.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        protected readonly DataContext _dataContext;

        public UnityOfWork(DataContext dataContext) {  _dataContext = dataContext; }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
