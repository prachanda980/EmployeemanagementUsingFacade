using Employeemanagement.Models;
using Employeemanagement.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employeemanagement.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> departments = new()
        {
            new Department { Id = 1, Name = "HR" },
            new Department { Id = 2, Name = "Finance" },
            new Department { Id = 3, Name = "IT" },
            new Department { Id = 4, Name = "Marketing" },
            new Department { Id = 5, Name = "Sales" },
            new Department { Id = 6, Name = "Operations" }
        };

        public async Task<Department> GetDepartmentById(int ids)
        {
            var depart = departments.FirstOrDefault(d => d.Id == ids);
            return await Task.FromResult(depart);
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await Task.FromResult(departments);
        }
    }
}