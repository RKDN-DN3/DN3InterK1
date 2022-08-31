using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Models;
using System.Diagnostics;

namespace Quiz.Web.Controllers
{
    [Area("Admin")]
    public class ExaminationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;

        public ExaminationController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }

        //public IActionResult Index()
        //{
        //    QuestionBanksVM questionbanksVM = new QuestionBanksVM();
        //    questionbanksVM.questionbanks = _unitoWork.QuestionBank.GetAll().OrderBy(p => p.CreateDate);
        //    return View(questionbanksVM);
        //}



        [HttpGet]
        public IActionResult Create()
            {
            ExaminationVM vM = new ExaminationVM();
            vM.question_Banks = _unitoWork.QuestionBank.GetAll();
            vM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");

            if (vM.question_Banks.Count() > 0)
            {
                vM.count = new int[vM.question_Banks.Count()];
                int i = 0;
                foreach (var item in vM.question_Banks)
                {
                    vM.count[i] = 0;
                    foreach (var q in vM.questions)
                    {
                        if (item.Id == q.Id_Question_Bank)
                        {
                            vM.count[i]++;
                        }
                    }
                    i++;
                }
            }
            return View(vM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExaminationVM vM)
        {

            vM.examination.Id = Guid.NewGuid();
            vM.examination_Detail.Id_Exam = vM.examination.Id;
            _unitoWork.Examination.Add(vM.examination);
            _unitoWork.Save();
            return RedirectToAction("Index");
        }



        //[HttpGet("Admin/QuestionBank/Edit/{id:guid}")]
        //public IActionResult Edit(Guid? id)
        //{
        //    QuestionBanksVM vM = new QuestionBanksVM();
        //    if (id.HasValue && vM.questionbank != null)
        //    {
        //        vM.questionbank = _unitoWork.QuestionBank.GetT(x => x.Id == id.Value);
        //        return View(vM);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //    if (id.Value == null) { return View(vM); }
        //}

        //[HttpPost("Admin/QuestionBank/Edit/{id:guid}")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Guid? id, QuestionBanksVM vM)
        //{
        //    if (id != vM.questionbank.Id)
        //    {
        //        return NotFound();
        //    }
        //    string a = vM.questionbank.Name;
        //    vM.questionbank.UpdateDate = DateTime.Now;
        //    _unitoWork.QuestionBank.Update(vM.questionbank);
        //    _unitoWork.Save();
        //    return RedirectToAction("Index");
        //}



        //[HttpGet("Admin/QuestionBank/Delete/{id:guid}")]
        //public IActionResult Delete(Guid? id)
        //{
        //    QuestionBanksVM vM = new QuestionBanksVM();
        //    if (!id.HasValue)
        //    {
        //        return NotFound();
        //    }
        //    vM.questionbank = _unitoWork.QuestionBank.GetT(x => x.Id == id.Value);
        //    if (vM.questionbank != null)
        //    {
        //        return View(vM);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost("Admin/QuestionBank/Delete/{id:guid}"), ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteData(Guid? id)
        //{
        //    var questionbank = _unitoWork.QuestionBank.GetT(x => x.Id == id.Value);
        //    if (questionbank == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitoWork.QuestionBank.Delete(questionbank);
        //    _unitoWork.Save();
        //    TempData["success"] = "Question delete done!";
        //    return RedirectToAction("Index");
        //}



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}