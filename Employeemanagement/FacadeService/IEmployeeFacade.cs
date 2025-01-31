using Employeemanagement.Models;

namespace Employeemanagement.FacadeService
{
    public interface IEmployeeFacade
    {
      
            object GetEmployeeByid(int id);
            object GetEmployeeDetails(int id);
            object AddEmployee(Employee employee);
            object UpdateEmployee(int id, Employee employee);
            object DepartmentbyID(int id);
            object Department();
        object Employee();
        }
    }


