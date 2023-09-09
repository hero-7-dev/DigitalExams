using DigitalExams.IRepository;
using DigitalExams.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalExams.Controllers
{
    public class ExaminationQuestionController : Controller
    {
        private readonly IExaminationQuestionsRepository _repository;

        public ExaminationQuestionController(IExaminationQuestionsRepository repository)
        {
            _repository = repository;
        }

        // GET: ExaminationQuestion
        public IActionResult Index()
        {
            IEnumerable<ExaminationQuestion> questions = _repository.GetAllQuestions();
            return View(questions);
        }

        // GET: ExaminationQuestion/Details/5
        public IActionResult Details(int id)
        {
            ExaminationQuestion question = _repository.GetQuestionById(id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: ExaminationQuestion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExaminationQuestion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExaminationQuestion question)
        {
            if (ModelState.IsValid)
            {
                _repository.AddQuestion(question);
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: ExaminationQuestion/Edit/5
        public IActionResult Edit(int id)
        {
            ExaminationQuestion question = _repository.GetQuestionById(id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: ExaminationQuestion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ExaminationQuestion question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.UpdateQuestion(question);
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: ExaminationQuestion/Delete/5
        public IActionResult Delete(int id)
        {
            ExaminationQuestion question = _repository.GetQuestionById(id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: ExaminationQuestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteQuestion(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
