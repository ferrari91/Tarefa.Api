using Tarefa.Application.Interface;
using Tarefa.Application.Interface.DataBase;

namespace Tarefa.Application.Services
{
    public class DataService : IDataService
    {
        protected readonly IDataContext _dataContext;

        public DataService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateDataBaseAsync() => await _dataContext.CreateDataBaseAsync();
    }
}
