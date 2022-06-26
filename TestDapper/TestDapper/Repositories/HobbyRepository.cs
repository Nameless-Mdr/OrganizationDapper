using System;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using Npgsql;
using TestDapper.Interfaces;
using TestDapper.Models;

namespace TestDapper.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly string queryList = $@"
    select h.id as {nameof(Hobby.Id)},
    h.name as {nameof(Hobby.Name)}
    from emp_dep.hobby h";

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        private readonly NpgsqlConnection connection;

        public HobbyRepository()
        {
            connection = new NpgsqlConnection(_connectionString);
            connection.Open();
        }
        public bool Insert(Hobby entity)
        {
            string commandText = $"insert into emp_dep.departments (name)" +
                                 $"values (@name)";

            var queryArg = new
            {
                Name = entity.Name,
            };

            return connection.Execute(commandText, queryArg) > 0;
        }

        public Hobby Get(int id)
        {
            string commandText = $"{queryList} where id = @id";

            var hobby = connection.QueryFirstOrDefault<Hobby>(commandText, new { Id = id });

            return hobby;
        }

        public IEnumerable<Hobby> Select()
        {
            string commandText = $"{queryList} order by h.id";

            var hobby = connection.Query<Hobby>(commandText);

            return hobby;
            ;
        }

        public bool Delete(int id)
        {
            string commandText = $"delete from emp_dep.hobby where id = @id";

            return connection.Execute(commandText, new { Id = id }) > 0;
        }

        public void CreateTableIfNotExists()
        {
            var commandText = $"create table if not exists emp_dep.hobby (" +
                              $"id serial4," +
                              $"name text not null," +
                              $"constraint hobby_name_key unique (name)," +
                              $"constraint hobby_pk primary key (id)" +
                              $");";

            connection.Execute(commandText);
        }
    }
}
