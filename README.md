# Employee Management System

This project implements an **Employee Management System** using the **Facade Pattern** in ASP.NET Core.

## Features
- **Employee Management** (Add, Update, Retrieve Employee Details)
- **Department Management** (Retrieve Departments and Department Details)
- **Facade Pattern** implementation to decouple business logic
- **Dependency Injection** for repositories and services

## Project Structure
```
- Controllers
  - EmployeeController.cs
- FacadeService
  - IEmployeeFacade.cs
  - EmployeeFacade.cs
- Repositories
  - IEmployeeRepository.cs
  - EmployeeRepository.cs
  - IDepartmentRepository.cs
  - DepartmentRepository.cs
- Models
  - Employee.cs
  - Department.cs
```

## Code Overview

### 1. **Register Services in `Program.cs`**
Add dependency injection for repositories and facade:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeFacade, EmployeeFacade>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

### 2. **Facade Interface & Implementation**
```csharp
public interface IEmployeeFacade
{
    object GetEmployeeByid(int id);
    object GetEmployeeDetails(int id);
    object AddEmployee(Employee employee);
    object UpdateEmployee(int id, Employee employee);
    object DepartmentbyID(int id);
    object Department();
}
```

```csharp
public class EmployeeFacade : IEmployeeFacade
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeFacade(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    public object GetEmployeeByid(int id) => _employeeRepository.GetEmployeeById(id);
    public object GetEmployeeDetails(int id) => new
    {
        Employee = _employeeRepository.GetEmployeeById(id).Result,
        Department = _departmentRepository.GetDepartmentById(id).Result.Name
    };
    public object AddEmployee(Employee employee) => _employeeRepository.AddEmployee(employee);
    public object UpdateEmployee(int id, Employee employee) => _employeeRepository.UpdateEmployee(id, employee);
    public object DepartmentbyID(int id) => _departmentRepository.GetDepartmentById(id);
    public object Department() => _departmentRepository.GetDepartments();
}
```

### 3. **Controller Implementation**
```csharp
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeFacade _employeeFacade;
    public EmployeeController(IEmployeeFacade employeeFacade)
    {
        _employeeFacade = employeeFacade;
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = _employeeFacade.GetEmployeeByid(id);
        return employee == null ? NotFound("Employee not found") : Ok(employee);
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody] Employee employee)
    {
        var result = _employeeFacade.AddEmployee(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, result);
    }
}
```

## How to Run
1. Clone the repository
2. Open the project in **Visual Studio**
3. Install dependencies using `dotnet restore`
4. Run the application using `dotnet run`
5. Use **Postman** or any API client to test the endpoints

## API Endpoints
| Method | Endpoint | Description |
|--------|---------|-------------|
| GET | `/api/employee/employeeList` | Get employee all employee |
| GET | `/api/employee/{id}` | Get employee by ID |
| GET | `/api/employee/details/{id}` | Get employee details with department |
| POST | `/api/employee` | Add a new employee |
| PUT | `/api/employee/{id}` | Update an employee |
| GET | `/api/employee/department/{id}` | Get department by ID |
| GET | `/api/employee/departments` | Get all departments |




