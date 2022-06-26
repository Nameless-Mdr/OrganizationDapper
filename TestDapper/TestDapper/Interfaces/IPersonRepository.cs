using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDapper.Models;

namespace TestDapper.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        public Person GetByName(string name);

        public void CreateTableIfNotExists();
    }
}
