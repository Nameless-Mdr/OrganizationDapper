using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Contracts.Interfaces;
using Contracts.Models;
using Service.Interfaces;

namespace Organization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Project> GetAll()
        {
            var response = _projectService.GetAll();

            return response;
        }

        [HttpGet]
        [Route("get")]
        public Project Get(int id)
        {
            var response = _projectService.Get(id);

            return response;
        }

        [HttpPost]
        [Route("save")]
        public int Save([FromBody] Project entity)
        {
            if (entity.Id == 0)
            {
                var response = _projectService.Insert(entity);

                return response;
            }
            else
            {
                var response = _projectService.Update(entity);

                return response;
            }

            return 0;
        }

        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            var response = _projectService.Delete(id);

            return response;
        }
    }
}