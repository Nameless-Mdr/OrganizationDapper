using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Contracts.Models;
using Service.Interfaces;

namespace Organization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonProjectController : ControllerBase
    {
        private readonly IPersonProjectService _personProjectService;

        public PersonProjectController(IPersonProjectService personProjectService)
        {
            _personProjectService = personProjectService;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<PersonProject> Get()
        {
            var response = _personProjectService.GetAll();

            return response;
        }

        [HttpGet]
        [Route("getPersons")]
        public IEnumerable<PersonProject> GetPersons(int id)
        {
            var response = _personProjectService.GetPersons(id);

            return response;
        }

        [HttpGet]
        [Route("getProjects")]
        public IEnumerable<PersonProject> GetProjects(int id)
        {
            var response = _personProjectService.GetProjects(id);

            return response;
        }

        [HttpPost]
        [Route("save")]
        public int Save([FromBody] PersonProject entity)
        {
            var response = _personProjectService.Insert(entity);

            return response;
        }

        [HttpDelete]
        [Route("delete")]
        public bool Delete(int persinId, int projectId)
        {
            var response = _personProjectService.Delete(persinId, projectId);

            return response;
        }
    }
}