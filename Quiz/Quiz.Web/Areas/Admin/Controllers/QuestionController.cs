using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Models;
using System.Diagnostics;

namespace Quiz.Web.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;

        public QuestionController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }

        public IActionResult Index()
        {
            QuestionsVM questionsVM = new QuestionsVM();
            questionsVM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");
            return View(questionsVM);
        }

        [HttpGet]
        public IActionResult UpSert(Guid? guid)
        {
            QuestionsVM vM = new QuestionsVM();
            if (guid.HasValue && vM.question != null)
            {
                vM.question = _unitoWork.Question.GetT(x => x.Id == guid.Value);
                return View(vM);
            }
            else
            {
                return NotFound();
            }

            if (guid.Value == null) { return View(vM); }
        }

        [HttpPost]
        public IActionResult UpSert(QuestionsVM vM)
        {
            
            return RedirectToAction("Index");
        }

        [HttpGet("{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            QuestionsVM vM = new QuestionsVM();
            vM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");

            if (!id.HasValue)
            //if (guid == null)
            {
                return NotFound();
            }
            vM.question = _unitoWork.Question.GetT(x => x.Id == id.Value);
            foreach (var item in vM.questions)
            {
                if (vM.question.Id_Question_Bank == item.Id_Question_Bank)
                {
                    vM.question.Question_Bank.Name = item.Question_Bank.Name;
                }
            }
            if (vM.question != null)
            {
                return View(vM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("{id:guid}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(Guid? id)
        {
            var question = _unitoWork.Question.GetT(x => x.Id == id.Value);
            if (question == null)
            {
                return NotFound();
            }
            
            _unitoWork.Question.Delete(question);
            _unitoWork.Save();
            TempData["success"] = "Question delete done!";
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}