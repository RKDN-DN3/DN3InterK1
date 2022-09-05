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


        [HttpGet]
        public IActionResult Create()
            {
            ExaminationVM vM = new ExaminationVM();
            vM.question_Banks = _unitoWork.QuestionBank.GetAll();
            vM.Examination_CategoryVMs = _unitoWork.Examination_CategoryVM.GetAll();
            vM.questions = _unitoWork.Question.GetAll(includeProperties: "Question_Bank");

            //if (vM.question_Banks.Count() > 0)
            //{
            //    vM.count = new int[vM.question_Banks.Count()];
            //    int i = 0;
            //    foreach (var item in vM.Examination_CategoryVMs)
            //    {
            //        item.questionbank
            //        vM.count[i] = 0;
            //        foreach (var q in vM.questions)
            //        {
            //            if (item.Id == q.Id_Question_Bank)
            //            {
            //                vM.count[i]++;
            //            }
            //        }
            //        i++;
            //    }
            //    foreach (var item in vM.question_Banks)
            //    {
            //        vM.Examination_CategoryVMs
            //        vM.count[i] = 0;
            //        foreach (var q in vM.questions)
            //        {
            //            if (item.Id == q.Id_Question_Bank)
            //            {
            //                vM.count[i]++;
            //            }
            //        }
            //        i++;
            //    }
            //}
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

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}