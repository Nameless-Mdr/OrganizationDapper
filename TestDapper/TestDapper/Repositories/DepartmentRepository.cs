using System.Collections.Generic;
using System.Configuration;
using Dapper;
using Npgsql;
using TestDapper.Interfaces;
using TestDapper.Models;

namespace TestDapper.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string queryList = $@"
    select d.id as {nameof(Department.Id)},
    d.name as {nameof(Department.Name)}
    from emp_dep.departments d";

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        private readonly NpgsqlConnection connection;

        public DepartmentRepository()
        {
            connection = new NpgsqlConnection(_connectionString);
            connection.Open();
        }

        public bool Insert(Department entity)
        {
            string commandText = $"insert into emp_dep.departments (name)" +
                                 $"values (@name)";

            var queryArg = new
            {
                Name = entity.Name,
            };

            return connection.Execute(commandText, queryArg) > 0;
        }

        public Department Get(int id)
        {
            string commandText = $"{queryList} where id = @id";

            var department = connection.QueryFirstOrDefault<Department>(commandText, new { Id = id });

            return department;
        }

        public IEnumerable<Department> Select()
        {
            string commandText = $"{queryList} order by d.id";

            var departments = connection.Query<Department>(commandText);

            return departments;
        }

        public bool Delete(int id)
        {
            string commandText = $"delete from emp_dep.departments where id = @id";

            return connection.Execute(commandText, new { Id = id }) > 0;
        }

        public void CreateTableIfNotExists()
        {
            var commandText = $"create table if not exists emp_dep.departments (" +
                              $"id serial4," +
                              $"name text not null," +
                              $"constraint departments_name_key unique (name)," +
                              $"constraint departments_pk primary key (id)" +
                              $");";

            connection.Execute(commandText);
        }
    }
}
