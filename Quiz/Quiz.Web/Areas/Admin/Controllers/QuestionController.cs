using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace Quiz.Web.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment mxHostingEnvironment { get; set; }

        public QuestionController(IUnitOfWork unitoWork, ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _unitoWork = unitoWork;
            mxHostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            QuestionsVM questionsVM = new QuestionsVM();
            questionsVM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank").OrderBy(p=>p.CreateDate);
            return View(questionsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            QuestionsVM vM = new QuestionsVM();
            vM.question_Banks = _unitoWork.Question_Bank.GetAll();

            return View(vM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( QuestionsVM vM)
        {

            if (vM.File != null)  //handle iformfile
            {
                //upload files to wwwroot
                var fileName = Path.GetFileName(vM.File.FileName);
                var filePath = mxHostingEnvironment.ContentRootPath + "wwwroot\\Images";
                string fileNameWithPath = Path.Combine(filePath, fileName);

                using (var fileSteam = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    vM.File.CopyToAsync(fileSteam);
                }
                vM.question.ImageUrl = fileNameWithPath;
            }
            vM.question.IsDelete = "0";
            vM.question.Id = Guid.NewGuid();
            vM.question.CreateDate = DateTime.Now;
            _unitoWork.Question.Add(vM.question);
            _unitoWork.Save();
            return RedirectToAction("Index");
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