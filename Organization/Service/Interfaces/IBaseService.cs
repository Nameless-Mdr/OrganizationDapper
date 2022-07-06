using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IBaseService<T>
    {
        int Insert(T entity);

        IEnumerable<T> GetAll();

        T Get(int id);

        bool Delete(int id);

        int Update(T entity);
    }
}
