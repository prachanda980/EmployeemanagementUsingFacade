using Employeemanagement.Models;
using Employeemanagement.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employeemanagement.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = new()
        {
            new Employee{Id=1, Name="Pracnada", PhoneNumber=89347493, DepartmentId=1, Salary=12020020},
            new Employee { Id = 2, Name = "John Doe", PhoneNumber = 987654321, DepartmentId = 2, Salary = 85000 },
            new Employee { Id = 3, Name = "Jane Smith", PhoneNumber = 876543210, DepartmentId = 1, Salary = 92000 },
            new Employee { Id = 4, Name = "Michael Johnson", PhoneNumber = 765432109, DepartmentId = 3, Salary = 102500 },
            new Employee { Id = 5, Name = "Emily Brown", PhoneNumber = 654321098, DepartmentId = 2, Salary = 98000 },
            new Employee { Id = 6, Name = "David Wilson", PhoneNumber = 543210987, DepartmentId = 4, Salary = 110000 },
            new Employee { Id = 7, Name = "Sophia Martinez", PhoneNumber = 432109876, DepartmentId = 3, Salary = 105000 }
        };

        public async Task<Employee> AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return await Task.FromResult(employee);
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await Task.FromResult(employees);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(employee);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.PhoneNumber = updatedEmployee.PhoneNumber;
                employee.DepartmentId = updatedEmployee.DepartmentId;
                employee.Salary = updatedEmployee.Salary;
            }
            return await Task.FromResult(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        
    }
}
