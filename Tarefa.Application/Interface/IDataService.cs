namespace Tarefa.Application.Interface
{
    public interface IDataService
    {
        Task<bool> CreateDataBaseAsync();
    }
}
