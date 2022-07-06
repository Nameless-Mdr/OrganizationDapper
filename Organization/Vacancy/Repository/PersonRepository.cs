using System;
using Dapper;
using System.Collections.Generic;
using Connection.Base;
using Contracts.Interfaces;
using Contracts.Models;

namespace Vacancy.Repository
{
    public class PersonRepository : DbConnectionRepository1, IPersonRepository
    {
        private readonly string _query = $@"
select p.id as {nameof(Person.Id)},
p.name as {nameof(Person.Name)},
p.surname as {nameof(Person.Surname)},
p.age as {nameof(Person.Age)},
p.salary as {nameof(Person.Salary)},
p.department_id as {nameof(Person.DepartmentId)}
from info.persons p";
        
        public PersonRepository(IDbConnectionFactory dbConnectionFactory)
            : base(dbConnectionFactory) { }

        public int Insert(Person entity)
        {
            var commandText = $@"
            insert into info.persons (name, surname, age, salary, department_id)
            values (@{nameof(Person.Name)}, @{nameof(Person.Surname)}, @{nameof(Person.Age)}, @{nameof(Person.Salary)}, @{nameof(Person.DepartmentId)})
            returning id";

            return DbConnection.ExecuteScalar<int>(commandText, entity);
        }

        public Person Get(int id)
        {
            var commandText = $@"{_query} where id = @{nameof(Person.Id)}";

            return DbConnection.QueryFirstOrDefault<Person>(commandText, new { Id = id });
        }

        public IEnumerable<Person> GetAll()
        {
            var commandText = $@"{_query} order by p.id";

            return DbConnection.Query<Person>(commandText);
        }

        public bool Delete(int id)
        {
            var commandText = $"delete from info.persons where id = @{nameof(Person.Id)}";

            return DbConnection.Execute(commandText, new { Id = id }) > 0;
        }

        public int Update(Person entity)
        {
            if (entity.Id != null && Get((int)entity.Id) == null)
                return 0;
            
            var queryUpdate = $@"
update info.persons set
name=:{nameof(Person.Name)},
surname=:{nameof(Person.Surname)},
age=:{nameof(Person.Age)},
salary=:{nameof(Person.Salary)},
department_id=:{nameof(Person.DepartmentId)}
where id=:{nameof(Person.Id)}";

            DbConnection.Query(queryUpdate, entity);

            return entity.Id.Value;
        }

        public IEnumerable<Person> PersonsJoinDepartments()
        {
            var commandText = $@"
select p.id as {nameof(Person.Id)}, 
p.name as {nameof(Person.Name)}, 
p.surname as {nameof(Person.Surname)}, 
p.age as {nameof(Person.Age)}, 
p.salary as {nameof(Person.Salary)}, 
p.department_id as {nameof(Person.DepartmentId)}, 
d.name as {nameof(Person.DepartmentName)} 
from info.persons p 
join info.departments d 
on p.department_id = d.id";

            return DbConnection.Query<Person>(commandText);
        }

        public IEnumerable<Person> PersonsJoinProject()
        {
            var commandText = $@"
select p.id as {nameof(Person.Id)},
p.name as {nameof(Person.Name)},
p.surname as {nameof(Person.Surname)},
p.age as {nameof(Person.Age)},
p.salary as {nameof(Person.Salary)},
p.department_id as {nameof(Person.DepartmentId)},
p2.id as {nameof(Person.ProjectId)}, 
p2.name as {nameof(Person.ProjectName)}
from info.persons p
inner join info.pers_proj pp ON p.id = pp.person_id 
inner join info.projects p2 on pp.project_id = p2.id";

            return DbConnection.Query<Person>(commandText);
        }
    }
}
