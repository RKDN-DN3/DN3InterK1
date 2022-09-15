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
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _HostingEnvironment { get; set; }

        public QuestionController(IUnitOfWork unitoWork, ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _unitoWork = unitoWork;
            _HostingEnvironment = hostingEnvironment;
        }

        [HttpGet("Admin/Question/Index")]
        public IActionResult Index()
        {
            QuestionsVM questionsVM = new QuestionsVM();

            questionsVM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank").Where(p=>p.IsDelete =="0").OrderBy(p => p.CreateDate);
            return View(questionsVM);
        }

        [HttpGet("Admin/Question/Detail/{id:guid}")]
        public IActionResult Detail(Guid? id)
        {
            QuestionsVM vM = new QuestionsVM();
            vM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");
            vM.answers = _unitoWork.Answer.GetAll(includeProperties: "Question").Where(x => x.Question.Id == id.Value && x.IsDelete == "0");
            foreach (var item in vM.questions)
            {
                if (vM.question.Id_Question_Bank == item.Id_Question_Bank)
                {
                    vM.question.Question_Bank.Name = item.Question_Bank.Name;
                }
            }
            vM.question = _unitoWork.Question.GetT(x => x.Id == id.Value);
            if (vM.question == null)
            {
                return NotFound();
            }
            string a = vM.question.ImageUrl;
            return View(vM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            QuestionsVM vM = new QuestionsVM();
            vM.question_Banks = _unitoWork.QuestionBank.GetAll();

            return View(vM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( QuestionsVM vM)
        {
            vM.question.ImageUrl = ProcessUploadedFile(vM);
            vM.question.IsDelete = "0";
            vM.question.Id = Guid.NewGuid();
            vM.question.CreateDate = DateTime.Now;
            _unitoWork.Question.Add(vM.question);
            _unitoWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Question/Edit/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            QuestionsVM vM = new QuestionsVM();
            if (id.HasValue && vM.question != null)
            {
                vM.question = _unitoWork.Question.GetT(x => x.Id == id.Value);
                vM.question_Banks = _unitoWork.QuestionBank.GetAll();
                if (vM.question.ImageUrl != null)
                    vM.ExistingImage = vM.question.ImageUrl;
                else
                    vM.ExistingImage = null;
                return View(vM);
            }
            else
            {
                return NotFound();
            }

            if (id.Value == null) { return View(vM); }
        }

        [HttpPost("Admin/Question/Edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, QuestionsVM vM)
        {
            if (id != vM.question.Id)
            {
                return NotFound();
            }
                if (vM.File != null)
            {
                vM.question.ImageUrl = ProcessUploadedFile(vM);
            }
            else
            {
                vM.question.ImageUrl = vM.ExistingImage;
            }
            vM.question.IsDelete = "0";
            vM.question.UpdateDate = DateTime.Now;
            vM.question.UserUpdate = "";
            _unitoWork.Question.Update(vM.question);
            _unitoWork.Save();
            return RedirectToAction("Index");
        }

        [HttpPost("Delete/{id:guid}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(Guid? id)
        {
            var question = _unitoWork.Question.GetT(x => x.Id == id.Value);
            if (question == null)
            {
                return NotFound();
            }
            question.IsDelete = "1";
            _unitoWork.Question.Update(question);
            _unitoWork.Save();
            TempData["success"] = "Question delete done!";
            return RedirectToAction("Index");


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string ProcessUploadedFile(QuestionsVM vM)
        {
            string uniqueFileName = null;

            if (vM.File != null)
            {
                string path = Path.Combine(_HostingEnvironment.WebRootPath, "Images");
                uniqueFileName = vM.File.FileName;
                string filePath = Path.Combine(path, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vM.File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        #region API

        public IActionResult AllQuestions()
        {
            var questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");

            return Json(new { data = questions });
        }

        #endregion API
    }
}