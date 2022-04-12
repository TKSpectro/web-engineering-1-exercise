namespace E01_student_mvc.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string StudentNumber { get; set; }

        public string Course { get; set; }

        public string Specialization { get; set; }

        public int Semester { get; set; }

        public DateOnly ExpectedGraduation { get; set; }
    }
}