using MVCPatternExample;

Student student = new Student
{
    Id = 101,
    Name = "Prahllad",
    Grade = "A"
};

StudentView view = new StudentView();

StudentController controller = new StudentController(student, view);

controller.DisplayStudent();

Console.WriteLine();

controller.UpdateStudent("G. Prahllad Reddy", "A+");

controller.DisplayStudent();