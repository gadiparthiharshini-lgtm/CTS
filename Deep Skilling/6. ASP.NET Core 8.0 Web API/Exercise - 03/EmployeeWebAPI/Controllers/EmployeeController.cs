using Microsoft.AspNetCore.Mvc;
using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> Get()
    {
        return GetStandardEmployeeList();
    }

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 50000,
                Permanent = true,
                Department = new Department
                {
                    Id = 1,
                    Name = "IT"
                },
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Id = 1,
                        Name = "C#"
                    },
                    new Skill
                    {
                        Id = 2,
                        Name = "ASP.NET Core"
                    }
                },
                DateOfBirth = new DateTime(1998, 5, 20)
            }
        };
    }
}