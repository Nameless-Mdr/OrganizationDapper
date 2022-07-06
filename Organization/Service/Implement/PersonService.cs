using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Interfaces;
using Contracts.Models;
using Service.Interfaces;

namespace Service.Implement
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public int Insert(Person entity)
        {
            try
            {
                var result = _personRepository.Insert(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[InsertPerson]: {ex.Message}");
            }
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                var persons = _personRepository.GetAll();

                if (persons.Any())
                {
                    return persons;
                }

                return new List<Person>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetPersons]: {ex.Message}");
            }
        }

        public Person Get(int id)
        {
            try
            {
                var person = _personRepository.Get(id);

                return person ?? new Person();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetPerson]: {ex.Message}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _personRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"[DeletePerson]: {ex.Message}");
            }
        }

        public int Update(Person entity)
        {
            try
            {
                var result = _personRepository.Update(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[UpdatePerson]: {ex.Message}");
            }
        }

        public IEnumerable<Person> GetAllWithDepart()
        {
            try
            {
                var persons = _personRepository.PersonsJoinDepartments();

                if (persons.Any())
                {
                    return persons;
                }

                return new List<Person>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetPersons]: {ex.Message}");
            }
        }

        public IEnumerable<Person> GetAllWithProject()
        {
            try
            {
                var persons = _personRepository.PersonsJoinProject();

                if (persons.Any())
                {
                    return persons;
                }

                return new List<Person>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetPersons]: {ex.Message}");
            }
        }
    }
}
