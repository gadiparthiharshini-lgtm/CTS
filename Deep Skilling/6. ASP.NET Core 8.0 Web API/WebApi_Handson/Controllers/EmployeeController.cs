using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Handson.Models;

namespace WebApi_Handson.Controllers;

// Hands-on 3/4/5: EmployeeController with Read/Write actions over a custom
// model class.
//
// Hands-on 3 originally guarded this controller with [CustomAuthFilter].
// Hands-on 5 replaces that with the built-in [Authorize] attribute driven by
// JWT validation, and restricts access to the "POC" and "Admin" roles. A
// request without a valid Bearer token gets a 401 Unauthorized; a valid token
// whose role is neither POC nor Admin gets 403 Forbidden.
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "POC,Admin")]
public class EmployeeController : ControllerBase
{
    // Hardcoded in-memory store shared across requests (Hands-on 4).
    private static readonly List<Employee> _employees = GetStandardEmployeeList();

    // Hands-on 3: private method that returns a standard list of employees.
    private static List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alice",
                Salary = 90000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "Engineering" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "ASP.NET Core" }
                },
                DateOfBirth = new DateTime(1995, 5, 20)
            },
            new Employee
            {
                Id = 2,
                Name = "Bob",
                Salary = 60000,
                Permanent = false,
                Department = new Department { Id = 2, Name = "Sales" },
                Skills = new List<Skill> { new Skill { Id = 3, Name = "CRM" } },
                DateOfBirth = new DateTime(1990, 11, 2)
            }
        };
    }

    // Hands-on 3: GET returns the list of employees.
    // ProducesResponseType documents the 200 response in Swagger.
    [HttpGet]
    [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> Get()
    {
        return Ok(_employees);
    }

    // GET api/employee/1 - single employee by id (named route).
    [HttpGet("{id}", Name = "GetEmployeeById")]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> GetById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        return employee is null ? NotFound() : Ok(employee);
    }

    // Hands-on 3: action that deliberately throws so the CustomExceptionFilter
    // can be exercised. ProducesResponseType documents the 500 in Swagger.
    [HttpGet("error")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult GetError()
    {
        throw new InvalidOperationException("Deliberate exception to test CustomExceptionFilter.");
    }

    // Hands-on 4: create a new employee from the request body.
    [HttpPost]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
    public ActionResult<Employee> Create([FromBody] Employee employee)
    {
        employee.Id = _employees.Count == 0 ? 1 : _employees.Max(e => e.Id) + 1;
        _employees.Add(employee);
        return CreatedAtRoute("GetEmployeeById", new { id = employee.Id }, employee);
    }

    // Hands-on 4: update an existing employee.
    //   id <= 0                       -> 400 "Invalid employee id"
    //   id valid but not in the list  -> 400 "Invalid employee id"
    //   otherwise update and return the updated employee.
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> Update(int id, [FromBody] Employee input)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existing = _employees.FirstOrDefault(e => e.Id == id);
        if (existing is null)
        {
            return BadRequest("Invalid employee id");
        }

        existing.Name = input.Name;
        existing.Salary = input.Salary;
        existing.Permanent = input.Permanent;
        existing.Department = input.Department;
        existing.Skills = input.Skills;
        existing.DateOfBirth = input.DateOfBirth;

        return Ok(existing);
    }

    // Hands-on 4: delete an employee.
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existing = _employees.FirstOrDefault(e => e.Id == id);
        if (existing is null)
        {
            return BadRequest("Invalid employee id");
        }

        _employees.Remove(existing);
        return NoContent();
    }
}
