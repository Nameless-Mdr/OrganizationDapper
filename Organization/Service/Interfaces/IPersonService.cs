using System.Collections.Generic;
using Contracts.Models;

namespace Service.Interfaces
{
    public interface IPersonService : IBaseService<Person>
    {
        IEnumerable<Person> GetAllWithDepart();

        IEnumerable<Person> GetAllWithProject();
    }
}
