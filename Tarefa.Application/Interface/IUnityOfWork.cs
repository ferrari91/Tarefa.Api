namespace Tarefa.Application.Interface
{
    public interface IUnityOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
