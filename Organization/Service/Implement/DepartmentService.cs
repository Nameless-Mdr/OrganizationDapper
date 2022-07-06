using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Interfaces;
using Contracts.Models;
using Service.Interfaces;

namespace Service.Implement
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int Insert(Department entity)
        {
            try
            {
                var result = _departmentRepository.Insert(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[InsertDepartment]: {ex.Message}");
            }
        }

        public IEnumerable<Department> GetAll()
        {
            try
            {
                var departments = _departmentRepository.GetAll();

                if (departments.Any())
                {
                    return departments;
                }

                return new List<Department>();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetDepartments]: {ex.Message}");
            }
        }

        public Department Get(int id)
        {
            try
            {
                var department = _departmentRepository.Get(id);

                return department ?? new Department();
            }
            catch (Exception ex)
            {
                throw new Exception($"[GetDepartment]: {ex.Message}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _departmentRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"[DeleteDepartment]: {ex.Message}");
            }
        }

        public int Update(Department entity)
        {
            try
            {
                var result = _departmentRepository.Update(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"[UpdateDepartment]: {ex.Message}");
            }
        }
    }
}
