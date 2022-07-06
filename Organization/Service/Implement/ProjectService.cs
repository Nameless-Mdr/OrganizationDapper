using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Interfaces;
using Contracts.Models;
using Service.Interfaces;

namespace Service.Implement
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public int Insert(Project entity)
        {
            try
            {
                var result = _projectRepository.Insert(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[InsertProject]: {ex.Message}");
            }
        }

        public IEnumerable<Project> GetAll()
        {
            try
            {
                var projects = _projectRepository.GetAll();

                if (projects.Any())
                {
                    return projects;
                }

                return new List<Project>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetProjects]: {ex.Message}");
            }
        }

        public Project Get(int id)
        {
            try
            {
                var project = _projectRepository.Get(id);

                return project ?? new Project();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetProject]: {ex.Message}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _projectRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"[DeleteProject]: {ex.Message}");
            }
        }

        public int Update(Project entity)
        {
            try
            {
                var result = _projectRepository.Update(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[UpdateProject]: {ex.Message}");
            }
        }
    }
}
