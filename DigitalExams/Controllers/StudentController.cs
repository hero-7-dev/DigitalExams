using DigitalExams.IRepository;
using DigitalExams.Models;
using DigitalExams.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DigitalExams.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentsRepository _studentRepository;

        public StudentController(IStudentsRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentRepository.GetAllStudents();
            return View(students);
        }
    }
}
