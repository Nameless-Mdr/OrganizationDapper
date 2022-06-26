using TestDapper.Models;

namespace TestDapper.Interfaces
{
    public interface IHobbyRepository : IBaseRepository<Hobby>
    {
        public void CreateTableIfNotExists();
    }
}
