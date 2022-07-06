using System;
using System.Collections.Generic;
using Connection.Base;
using Contracts.Interfaces;
using Contracts.Models;
using Dapper;

namespace Vacancy.Repository
{
    public class DepartmentRepository : DbConnectionRepository1, IDepartmentRepository
    {
        private readonly string _query = $@"
    select d.id as {nameof(Department.Id)},
    d.name as {nameof(Department.Name)}
    from info.departments d";

        public DepartmentRepository(IDbConnectionFactory dbConnectionFactory)
            : base(dbConnectionFactory) { }

        public int Insert(Department entity)
        {
            string commandText = $@"
            insert into info.departments (name)
            values (@{nameof(Department.Name)}) 
            returning id";

            return DbConnection.ExecuteScalar<int>(commandText, entity);
        }

        public Department Get(int id)
        {
            var commandText = $"{_query} where id = @{nameof(Department.Id)}";

            return DbConnection.QueryFirstOrDefault<Department>(commandText, new { Id = id });
        }

        public IEnumerable<Department> GetAll()
        {
            var commandText = $"{_query} order by d.id";

            return DbConnection.Query<Department>(commandText);
        }

        public bool Delete(int id)
        {
            var commandText = $"delete from info.departments where id = @{nameof(Department.Id)}";

            return DbConnection.Execute(commandText, new { Id = id }) > 0;
        }

        public int Update(Department entity)
        {
            if (entity.Id != null && Get((int)entity.Id) == null)
                return 0;

            var queryUpdate = $@"
update info.departments set
name=:{nameof(Department.Name)}
where id=:{nameof(Department.Id)}";

            DbConnection.Query(queryUpdate, entity);

            return entity.Id.Value;
        }
    }
}
