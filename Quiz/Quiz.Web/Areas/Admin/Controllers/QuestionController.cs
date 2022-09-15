using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Utility.Enum;
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

        #region Index question
        public IActionResult Index()
        {
            QuestionsVM questionsVM = new QuestionsVM();

            questionsVM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank").Where(p => p.IsDelete == "0").OrderBy(p => p.CreateDate);
            return View(questionsVM);
        }
        #endregion

        #region Detail question

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

        #endregion Detail question

        #region Create question

        [HttpGet]
        public IActionResult Create()
        {
            QuestionsVM vm = new QuestionsVM();
            vm.QuestionBanks = GetQuestionBank();
            return View(vm);
        }

        private List<SelectListItem> GetQuestionBank() => _unitoWork.QuestionBank.GetAll()
            .OrderBy(a => a.Name)
            .Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.Name
            })
                            .ToList();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuestionsVM vM)
        {
            if (!ModelState.IsValid) return Create();

            vM.question.ImageUrl = ProcessUploadedFile(vM);
            vM.question.Id = Guid.NewGuid();
            vM.question.IsDelete = ConstQuiz.IsDelete_None;

            _unitoWork.Question.Add(vM.question);
            _unitoWork.Save();
            return RedirectToAction("Index");
        }

        #endregion Create

        #region Edit question

        [HttpGet("Admin/Question/Edit/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (Guid.Empty == id && !id.HasValue) return Index();

            QuestionsVM vM = new QuestionsVM();
            vM.question = _unitoWork.Question.GetT(x => x.Id == id.Value);
            if (vM.question == null)
            {
                return NotFound();
            }

            vM.QuestionBanks = GetQuestionBank();
            if (vM.question.ImageUrl != null)
            {
                vM.ExistingImage = vM.question.ImageUrl;
            }
            else
            {
                vM.ExistingImage = String.Empty;
            }
            return View(vM);
        }

        [HttpPost("Admin/Question/Edit/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, QuestionsVM vM)
        {
            if (!ModelState.IsValid) return Edit(id);

            if (id != vM.question.Id) return NotFound();
            if (vM.File != null)
            {
                vM.question.ImageUrl = ProcessUploadedFile(vM);
            }
            else
            {
                vM.question.ImageUrl = vM.ExistingImage;
            }
            vM.question.IsDelete = ConstQuiz.IsDelete_None;
            vM.question.UpdateDate = DateTime.Now;
            vM.question.UserUpdate = "";
            _unitoWork.Question.Update(vM.question);
            _unitoWork.Save();
            return RedirectToAction("Index");
        }

        #endregion Edit question

        #region Delete question
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

        #endregion

        private string ProcessUploadedFile(QuestionsVM vM)
        {
            string uniqueFileName = String.Empty;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region API Example

        public IActionResult AllQuestions()
        {
            var questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");

            return Json(new { data = questions });
        }

        #endregion API
    }
}