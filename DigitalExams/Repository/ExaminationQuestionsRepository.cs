using Dapper;
using DigitalExams.IRepository;
using DigitalExams.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DigitalExams.Repository
{
    public class ExaminationQuestionsRepository : IExaminationQuestionsRepository
    {
        private readonly IConfiguration _configuration;
        public ExaminationQuestionsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void AddQuestion(ExaminationQuestion question)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            IDbConnection _connection = new SqlConnection(connectionString);
            var query = "INSERT INTO ExaminationQuestions (QuestionText, QuestionType) VALUES (@QuestionText, @QuestionType)";
            _connection.Execute(query, question);
        }

        public void DeleteQuestion(int id)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            IDbConnection _connection = new SqlConnection(connectionString);
            var query = "DELETE FROM ExaminationQuestions WHERE Id = @Id";
            _connection.Execute(query, new { Id = id }); 
        }

        public IEnumerable<ExaminationQuestion> GetAllQuestions()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            IDbConnection _connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Questions";
            return _connection.Query<ExaminationQuestion>(query);

          
        }

        public ExaminationQuestion GetQuestionById(int id)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            IDbConnection _connection = new SqlConnection(connectionString);
            return _connection.QueryFirstOrDefault<ExaminationQuestion>("SELECT * FROM ExaminationQuestions WHERE Id = @Id", new { Id = id });
           
        }

        public void UpdateQuestion(ExaminationQuestion question)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            IDbConnection _connection = new SqlConnection(connectionString);
            var query = "UPDATE ExaminationQuestions SET QuestionText = @QuestionText, QuestionType = @QuestionType WHERE Id = @Id";
            _connection.Execute(query, question);
        }
    }
}
