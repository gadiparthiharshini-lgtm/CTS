namespace WebApi_Handson.Models;

// Hands-on 3: custom model class returned/accepted by EmployeeController.
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Salary { get; set; }
    public bool Permanent { get; set; }
    public Department? Department { get; set; }
    public List<Skill> Skills { get; set; } = new();
    public DateTime DateOfBirth { get; set; }
}
