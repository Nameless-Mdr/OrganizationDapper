using System.Collections.Generic;

namespace TestDapper.Interfaces
{
    public interface IBaseRepository<T>
    {
        public bool Insert(T entity);

        public T Get(int id);

        public IEnumerable<T> Select();

        bool Delete(int id);
    }
}
