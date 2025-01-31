using Employeemanagement.FacadeService;
using Employeemanagement.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeFacade _employeeFacade;

    public EmployeeController(IEmployeeFacade employeeFacade)
    {
        _employeeFacade = employeeFacade;
    }
    [HttpGet("employeeList")]
    public IActionResult GetAllEmployee()
    {
        var emp = _employeeFacade.Employee();
        return Ok(emp);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = _employeeFacade.GetEmployeeByid(id);
        if (employee == null)
            return NotFound("Employee not found");
        return Ok(employee);
    }

    [HttpGet("details/{id}")]
    public IActionResult GetEmployeeDetails(int id)
    {
        var employeeDetails = _employeeFacade.GetEmployeeDetails(id);
        if (employeeDetails == null)
            return NotFound("Employee details not found");
        return Ok(employeeDetails);
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody] Employee employee)
    {
        var result = _employeeFacade.AddEmployee(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
    {
        var result = _employeeFacade.UpdateEmployee(id, employee);
        return Ok(result);
    }

    [HttpGet("department/{id}")]
    public IActionResult GetDepartmentById(int id)
    {
        var department = _employeeFacade.DepartmentbyID(id);
        if (department == null)
            return NotFound("Department not found");
        return Ok(department);
    }

    [HttpGet("departments")]
    public IActionResult GetDepartments()
    {
        var departments = _employeeFacade.Department();
        return Ok(departments);
    }
}
