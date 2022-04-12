namespace E01_student_mvc.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string StudentNumber { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public int Semester { get; set; }

        public DateOnly ExpectedGraduation { get; set; }

        public bool Visible { get; set; }
    }
}