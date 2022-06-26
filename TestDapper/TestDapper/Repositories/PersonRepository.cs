using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Dapper;
using Npgsql;
using TestDapper.Interfaces;
using TestDapper.Models;

namespace TestDapper.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string queryList = $@"
select p.id as {nameof(Person.Id)},
p.name as {nameof(Person.Name)},
p.surname as {nameof(Person.Surname)},
p.age as {nameof(Person.Age)}
from emp_dep.persons p";

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        private readonly NpgsqlConnection connection;

        public PersonRepository()
        {
            connection = new NpgsqlConnection(_connectionString);
            connection.Open();
        }

        public bool Insert(Person entity)
        {
            string commandText = $"insert into emp_dep.persons (name, surname, age)" +
                                 $"values (@name, @surname, @age)";

            var queryArg = new
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Age = entity.Age
            };

            return connection.Execute(commandText, queryArg) > 0;
        }

        public Person Get(int id)
        {
            string commandText = $"{queryList} where id = @id";

            var persons = connection.QueryFirstOrDefault<Person>(commandText, new { Id = id });

            return persons;
        }

        public IEnumerable<Person> Select()
        {
            string commandText = $"{queryList} order by p.id";

            var persons = connection.Query<Person>(commandText);

            return persons;
        }

        public bool Delete(int id)
        {
            string commandText = $"delete from emp_dep.persons where id = @id";

            return connection.Execute(commandText, new { Id = id }) > 0;
        }

        public Person GetByName(string name)
        {
            string commandText = $"{queryList} where name = @name";

            var persons = connection.QueryFirstOrDefault<Person>(commandText, new { Name = name });

            return persons;
        }

        public void CreateTableIfNotExists()
        {
            var commandText = $"create table if not exists emp_dep.persons (" +
                              "id serial4," +
                              "name text not null," +
                              "surname text not null," +
                              "age int4 not null," +
                              "constraint persons_pk primary key(id)" +
                              ");";

            connection.Execute(commandText);
        }
    }
}
