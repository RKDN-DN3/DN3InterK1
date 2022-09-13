using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Controllers;

namespace Quiz.Web.Areas.User.Controllers
{
    [Area("User")]
    public class ExaminationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;

        public ExaminationController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }

        public IActionResult Index()
        {
            ExaminationVM vM = new ExaminationVM();
            vM.examinations = _unitoWork.Examination.GetAll().Where(p => p.IsDelete == "0");
            vM.account = _unitoWork.Account.GetAll().Where(p => p.Email_User == "thanhnq@gmail.com").FirstOrDefault();
            return View(vM);
        }
        public IActionResult DoExam(Guid? id)
        {
            ExaminationVM vM = new ExaminationVM();
            vM.examinations = _unitoWork.Examination.GetAll().Where(p => p.IsDelete == "0");
            vM.account = _unitoWork.Account.GetAll().Where(p => p.Email_User == "thanhnq@gmail.com").FirstOrDefault();
            return View(vM);
        }
    }
}
