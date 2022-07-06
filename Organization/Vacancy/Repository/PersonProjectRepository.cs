using System.Collections.Generic;
using Connection.Base;
using Contracts.Interfaces;
using Contracts.Models;
using Dapper;

namespace Vacancy.Repository
{
    public class PersonProjectRepository : DbConnectionRepository1, IPersonProjectRepository
    {
        private readonly string _query = $@"
        select pp.person_id as {nameof(PersonProject.PersonId)},
        pp.project_id as {nameof(PersonProject.ProjectId)}
        from info.pers_proj pp";

        public PersonProjectRepository(IDbConnectionFactory dbConnectionFactory)
            : base(dbConnectionFactory) { }

        public int Insert(PersonProject entity)
        {
            var commandText = $@"
            insert into info.pers_proj (person_id, project_id)
            values (@{nameof(PersonProject.PersonId)}, @{nameof(PersonProject.ProjectId)})
            returning person_id";

            return DbConnection.ExecuteScalar<int>(commandText, entity);
        }

        public IEnumerable<PersonProject> GetAll()
        {
            var commandText = $"{_query} order by pp.person_id";

            return DbConnection.Query<PersonProject>(commandText);
        }

        public bool Delete(int personId, int projectId)
        {
            var commandText = $"delete from info.pers_proj where person_id = @{nameof(PersonProject.PersonId)} and project_id = @{nameof(PersonProject.ProjectId)}";

            return DbConnection.Execute(commandText, new { PersonId = personId, ProjectId = projectId }) > 0;
        }

        public IEnumerable<PersonProject> GetPersons(int id)
        {
            var commandText = $"{_query} where pp.person_id = @{nameof(id)}";

            return DbConnection.Query<PersonProject>(commandText, new { id });
        }

        public IEnumerable<PersonProject> GetProjects(int id)
        {
            var commandText = $"{_query} where pp.project_id = @{nameof(id)}";

            return DbConnection.Query<PersonProject>(commandText, new { id });
        }
    }
}
