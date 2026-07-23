using EmployeeCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new()
    {
        new Employee { Id = 1, Name = "Rahul", Salary = 50000 },
        new Employee { Id = 2, Name = "Amit", Salary = 60000 },
        new Employee { Id = 3, Name = "Priya", Salary = 70000 }
    };

    [HttpPut("{id}")]
    public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var emp = employees.FirstOrDefault(e => e.Id == id);

        if (emp == null)
        {
            return BadRequest("Invalid employee id");
        }

        emp.Name = employee.Name;
        emp.Salary = employee.Salary;

        return Ok(emp);
    }
}