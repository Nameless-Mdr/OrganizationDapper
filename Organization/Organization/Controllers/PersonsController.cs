using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Organization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Person> GetAll()
        {
            var response = _personService.GetAll();

            return response;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Person Get(int id)
        {
            var response = _personService.Get(id);

            return response;
        }

        [HttpPost]
        [Route("save")]
        public int Save([FromBody] Person entity)
        {
            if (entity.Id == 0)
            {
                var response = _personService.Insert(entity);

                return response;
            }
            else
            {
                var response = _personService.Update(entity);

                return response;
            }
        }

        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            var response = _personService.Delete(id);

            return response;
        }

        [HttpGet]
        [Route("getAllWithDepartments")]
        public IEnumerable<Person> GetAllWithDepartments()
        {
            var response = _personService.GetAllWithDepart();

            return response;
        }

        [HttpGet]
        [Route("getAllWithProject")]
        public IEnumerable<Person> GetAllWithProject()
        {
            var response = _personService.GetAllWithProject();

            return response;
        }
    }
}
