using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Contracts.Models;
using Service.Interfaces;

namespace Organization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Department> GetAll()
        {
            var response = _departmentService.GetAll();

            return response;
        }

        [HttpGet]
        [Route("get")]
        public Department Get(int id)
        {
            var response = _departmentService.Get(id);

            return response;
        }

        [HttpPost]
        [Route("save")]
        public int Save([FromBody] Department entity)
        {
            if (entity.Id == 0)
            {
                var response = _departmentService.Insert(entity);

                return response;
            }
            else
            {
                var response = _departmentService.Update(entity);

                return response;
            }
        }

        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            var response = _departmentService.Delete(id);

            return response;
        }
    }
}