using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        IEnumerable<Person> PersonsJoinDepartments();

        IEnumerable<Person> PersonsJoinProject();
    }
}