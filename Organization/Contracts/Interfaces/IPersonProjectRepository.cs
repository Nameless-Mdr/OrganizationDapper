using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IPersonProjectRepository
    {
        int Insert(PersonProject entity);

        IEnumerable<PersonProject> GetAll();

        bool Delete(int personId, int projectId);

        IEnumerable<PersonProject> GetPersons(int id);

        IEnumerable<PersonProject> GetProjects(int id);
    }
}
