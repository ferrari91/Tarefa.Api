using Tarefa.Application.Interface;
using Tarefa.Infrastructure.DataBase;

namespace Tarefa.Infrastructure.Services
{
    public class DataService : IDataService
    {
        protected readonly DataContext _dataContext;

        public DataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateDataBaseAsync() => await _dataContext.Database.EnsureCreatedAsync();
    }
}
