using Employeemanagement.Models;

namespace Employeemanagement.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);

    }
}
