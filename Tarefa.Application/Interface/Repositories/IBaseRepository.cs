﻿namespace Tarefa.Application.Interface.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
