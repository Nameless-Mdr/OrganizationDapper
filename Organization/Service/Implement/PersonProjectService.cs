using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Interfaces;
using Contracts.Models;
using Service.Interfaces;

namespace Service.Implement
{
    public class PersonProjectService : IPersonProjectService
    {
        private readonly IPersonProjectRepository _personProjectRepository;

        public PersonProjectService(IPersonProjectRepository personProjectRepository)
        {
            _personProjectRepository = personProjectRepository;
        }

        public int Insert(PersonProject entity)
        {
            try
            {
                var result = _personProjectRepository.Insert(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[InsertEntry]: {ex.Message}");
            }
        }

        public IEnumerable<PersonProject> GetAll()
        {
            try
            {
                var entrys = _personProjectRepository.GetAll();

                if (entrys.Any())
                {
                    return entrys;
                }

                return new List<PersonProject>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetEntrys]: {ex.Message}");
            }
        }

        public IEnumerable<PersonProject> GetPersons(int id)
        {
            try
            {
                var entrys = _personProjectRepository.GetPersons(id);

                if (entrys.Any())
                {
                    return entrys;
                }

                return new List<PersonProject>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetPersons]: {ex.Message}");
            }
        }

        public IEnumerable<PersonProject> GetProjects(int id)
        {
            try
            {
                var entrys = _personProjectRepository.GetProjects(id);

                if (entrys.Any())
                {
                    return entrys;
                }

                return new List<PersonProject>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetProjects]: {ex.Message}");
            }
        }

        public bool Delete(int personId, int projectId)
        {
            try
            {
                var result = _personProjectRepository.Delete(personId, projectId);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[DeleteEntry]: {ex.Message}");
            }
        }
    }
}
