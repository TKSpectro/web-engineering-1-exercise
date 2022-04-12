using E01_student_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace E01_student_mvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            ViewBag.Title = "Student List";
            return View(Students);
        }

        public IActionResult Details(Guid id)
        {
            Student student = Students.First(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            if (!student.Visible)
            {
                return RedirectToAction("Forbidden", new { id = id });
            }


            ViewBag.Title = $"Student Details - {student.Firstname} {student.Lastname}";

            return View(student);
        }

        public IActionResult Forbidden(Guid id)
        {
            Student student = Students.First(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Title = $"Student Forbidden - {student.Firstname} {student.Lastname}";

            return View(student);
        }

        private static List<Student> Students => new List<Student>
        {
            new Student{
                Id = new Guid("f0d9b8e0-f8a1-4f5e-b8f4-f8b9b8e0f8a1"),
                Firstname = "John",
                Lastname = "Doe",
                StudentNumber = "123456789",
                Course = "Computer Science",
                Specialization = "Software Engineering",
                Semester = 1,
                ExpectedGraduation = new DateOnly(2024, 4, 30),
                Visible = true
            },
            new Student{
                Id = new Guid("f0d9b8e0-f8a1-4f5e-b8f4-f8b9b8e0f8a2"),
                Firstname = "Jane",
                Lastname = "Doe",
                StudentNumber = "987654321",
                Course = "Computer Science",
                Specialization = "Software Engineering",
                Semester = 3,
                ExpectedGraduation = new DateOnly(2023, 4, 30),
                Visible = false
            }
        };
    }
}