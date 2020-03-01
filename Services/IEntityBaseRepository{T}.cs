using System;
using System.Collections.Generic;

namespace BlazorGames.Services
{
    public interface IEntityBaseRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Func<T, bool> predicate);

        int Count();

        T GetSingle(Guid id);

        T GetSingle(Func<T, bool> predicate);

        T Create(T entity);

        void Update(Guid id, T entity);

        void Delete(T entity);

        void Delete(Guid id);
    }
}
