using TestDapper.Models;

namespace TestDapper.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        public void CreateTableIfNotExists();
    }
}
