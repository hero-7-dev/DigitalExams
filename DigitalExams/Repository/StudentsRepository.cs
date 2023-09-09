using Dapper;
using DigitalExams.IRepository;
using DigitalExams.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalExams.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly IConfiguration _configuration;
        
        public StudentsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }
        public IEnumerable<Student> GetAllStudents()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            IDbConnection _connection = new SqlConnection(connectionString);
            return _connection.Query<Student>("SELECT * FROM Students");
        }
    }
}
