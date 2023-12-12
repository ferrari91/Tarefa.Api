namespace Tarefa.Application.Interface.DataBase
{
    public interface IDataContext
    {
        Task<bool> CreateDataBaseAsync();
    }
}
