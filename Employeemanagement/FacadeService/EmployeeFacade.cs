using Employeemanagement.Models;
using Employeemanagement.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Employeemanagement.FacadeService
{
    public class EmployeeFacade: IEmployeeFacade
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public EmployeeFacade(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;


        }
        public object GetEmployeeByid(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null) return null;
            return employee;
        }

        public object GetEmployeeDetails(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null) return null;

            var department = _departmentRepository.GetDepartmentById(employee.Result.DepartmentId);

            return new
            {
                Employeeid = employee.Result.Id,
                EmployeeName =employee.Result.Name,
                EmployeePhoneNumber = employee.Result.PhoneNumber,
                Department = department.Result.Name,
                EmployeeSalary = employee.Result.Salary



            };

        }

        public object AddEmployee(Employee employee)
        {
           return  _employeeRepository.AddEmployee(employee);
        }

        public object UpdateEmployee(int id,Employee employee)
        {
            return _employeeRepository.UpdateEmployee(id, employee);
        }

        public object DepartmentbyID(int id)
        {
            return _departmentRepository.GetDepartmentById(id);
        }
        public object Department()
        {
            return _departmentRepository.GetDepartments();
        }

        public object Employee()
        {
            return _employeeRepository.GetAllEmployee();

        }
    }
}
