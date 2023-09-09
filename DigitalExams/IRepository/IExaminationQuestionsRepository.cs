using DigitalExams.Models;

namespace DigitalExams.IRepository
{
    public interface IExaminationQuestionsRepository
    {
        IEnumerable<ExaminationQuestion> GetAllQuestions();
        ExaminationQuestion GetQuestionById(int id);
        void AddQuestion(ExaminationQuestion question);
        void UpdateQuestion(ExaminationQuestion question);
        void DeleteQuestion(int id);
    }
}
