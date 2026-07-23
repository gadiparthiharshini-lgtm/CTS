namespace MVCPatternExample
{
    public class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void UpdateStudent(string name, string grade)
        {
            model.Name = name;
            model.Grade = grade;
        }

        public void DisplayStudent()
        {
            view.DisplayStudentDetails(model);
        }
    }
}