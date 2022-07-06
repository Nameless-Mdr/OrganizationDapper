using System.Collections.Generic;
using Connection.Base;
using Contracts.Interfaces;
using Contracts.Models;
using Dapper;

namespace Vacancy.Repository
{
    public class ProjectRepository : DbConnectionRepository1, IProjectRepository
    {
        private readonly string _query = $@"
select pr.id as {nameof(Project.Id)},
pr.name as {nameof(Project.Name)}
from info.projects pr";

        public ProjectRepository(IDbConnectionFactory dbConnectionFactory)
            : base(dbConnectionFactory) { }

        public int Insert(Project entity)
        {
            var commandText = $@"
            insert into info.projects (name)
            values (@{nameof(Project.Name)})
            returning id";

            return DbConnection.ExecuteScalar<int>(commandText, entity);
        }

        public IEnumerable<Project> GetAll()
        {
            var commandText = $"{_query} order by pr.id";

            return DbConnection.Query<Project>(commandText);
        }

        public Project Get(int id)
        {
            var commandText = $"{_query} where id = @{nameof(Project.Id)}";

            return DbConnection.QueryFirstOrDefault<Project>(commandText, new { Id = id });
        }

        public bool Delete(int id)
        {
            var commandText = $"delete from info.projects where id = @{nameof(Project.Id)}";

            return DbConnection.Execute(commandText, new { Id = id }) > 0;
        }

        public int Update(Project entity)
        {
            if (entity.Id != null && Get((int)entity.Id) == null)
                return 0;

            var queryUpdate = $@"
update info.projects set
name=:{nameof(Department.Name)}
where id=:{nameof(Department.Id)}";

            DbConnection.Query(queryUpdate, entity);

            return entity.Id.Value;
        }
    }
}