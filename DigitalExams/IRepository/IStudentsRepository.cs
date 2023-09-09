using DigitalExams.Models;

namespace DigitalExams.IRepository
{
    public interface IStudentsRepository
    {
       IEnumerable<Student> GetAllStudents();   
    }
}
