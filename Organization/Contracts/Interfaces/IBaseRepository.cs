using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IBaseRepository<T>
    {
        int Insert(T entity);

        IEnumerable<T> GetAll();

        T Get(int id);

        bool Delete(int id);

        int Update(T entity);
    }
}
