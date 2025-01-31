using System.ComponentModel.DataAnnotations;

namespace Employeemanagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}
