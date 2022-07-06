using System.Collections.Generic;
using Contracts.Models;

namespace Service.Interfaces
{
    public interface IPersonProjectService
    {
        int Insert(PersonProject entity);

        IEnumerable<PersonProject> GetAll();

        IEnumerable<PersonProject> GetPersons(int id);

        IEnumerable<PersonProject> GetProjects(int id);

        bool Delete(int personId, int projectId);
    }
}