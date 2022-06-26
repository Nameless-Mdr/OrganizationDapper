using System;
using System.Linq;
using TestDapper.Models;
using TestDapper.Repositories;

namespace TestDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            #region persons
            var PersonCon = new PersonRepository();

            var person1 = new Person()
            {
                Name = "Vova",
                Surname = "Pupkov",
                Age = 23
            };

            //PersonCon.Insert(person1);

            Console.WriteLine("----------------------------------------------");

            if (PersonCon.Delete(5))
                Console.WriteLine("Delete successful");
            else
                Console.WriteLine("Delete failed");

            Console.WriteLine("----------------------------------------------");

            var persons = PersonCon.Select().ToList();

            foreach (var per in persons)
            {
                Console.WriteLine($"{per.Id}    {per.Name}    {per.Surname}    {per.Age}");
            }

            Console.WriteLine("----------------------------------------------");

            var getId = PersonCon.Get(1);

            Console.WriteLine($"{getId?.Id}    {getId?.Name}    {getId?.Surname}    {getId?.Age}");

            Console.WriteLine("----------------------------------------------");

            var getName = PersonCon.GetByName("alex");

            Console.WriteLine($"{getName?.Id}    {getName?.Name}    {getName?.Surname}    {getName?.Age}");
            #endregion

            Console.WriteLine("--------------------------------------------------------------------------------------------");

            #region departments
            var depart = new DepartmentRepository();

            var dep1 = new Department()
            {
                Name = "dep4"
            };

            depart.CreateTableIfNotExists();

            //depart.Insert(dep1);

            Console.WriteLine("----------------------------------------------");

            if (depart.Delete(6))
                Console.WriteLine("Delete successful");
            else
                Console.WriteLine("Delete failed");

            Console.WriteLine("----------------------------------------------");

            var departs = depart.Select().ToList();

            foreach (var dep in departs)
            {
                Console.WriteLine($"{dep.Id}    {dep.Name}");
            }

            Console.WriteLine("----------------------------------------------");

            var getIdD = depart.Get(1);

            Console.WriteLine($"{getIdD?.Id}    {getIdD?.Name}");

            Console.WriteLine("----------------------------------------------");
            #endregion

            #region hobby

            var hobbyRep = new HobbyRepository();

            hobbyRep.CreateTableIfNotExists();
            #endregion

            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
