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
        private IWebHostEnvironment _webHostEnvironment;

        public QuestionController(IUnitOfWork unitoWork, ILogger<HomeController> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _unitoWork = unitoWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            QuestionsVM questionsVM = new QuestionsVM();
            questionsVM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank").OrderBy(p => p.CreateDate);
            return View(questionsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            QuestionsVM vM = new QuestionsVM();
            vM.question_Banks = _unitoWork.QuestionBank.GetAll().OrderBy(p => p.Name);
            return View(vM);
        }

        [HttpGet]
        public IActionResult Edit(Guid? guid)
        {
            QuestionsVM vM = new QuestionsVM();
            if (guid.HasValue)
            {
                vM.question = _unitoWork.Question.GetT(x => x.Id == guid.Value);
                return View(vM);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create(QuestionsVM vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (vM.question != null)
            {
                string wwwPath = this._webHostEnvironment.WebRootPath;

                string path = Path.Combine(wwwPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileNameWithoutExtension(vM.FileUpload.FileName) 
                    + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(vM.FileUpload.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    vM.FileUpload.CopyTo(stream);
                    vM.question.ImageUrl = "/uploads/" + fileName;
                }
                vM.question.Id = new Guid();
                vM.question.IsDelete = "0";
                _unitoWork.Question.Add(vM.question);
                _unitoWork.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return NotFound();
            }
            var question = _unitoWork.Question.GetT(x => x.Id == guid.Value);
            if (question != null)
            {
                return View(question);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
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

        #region API
        public IActionResult AllQuestions()
        {
            var questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");

            return Json(new { data = questions });
        }
        #endregion
    }
}