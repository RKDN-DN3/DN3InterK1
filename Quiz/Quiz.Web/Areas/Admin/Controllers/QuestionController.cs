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
            questionsVM.questions = _unitoWork.Question.GetAll();
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

        [HttpGet]
        public IActionResult Delete(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return NotFound();
            }
            var question = _unitoWork.Question.GetT(x=> x.Id == guid.Value);
            if(question != null)
            {
                return View(question);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteData(Guid? guid)
        {
            var question = _unitoWork.Question.GetT(x => x.Id == guid.Value);
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