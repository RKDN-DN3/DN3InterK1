using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Controllers;

namespace Quiz.Web.Areas.User.Controllers
{
    [Area("User")]
    public class HistoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;

        public HistoryController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }

        public IActionResult Index()
        {
            ExamHistoryVM examHistoryVM = new ExamHistoryVM();
            examHistoryVM.account = _unitoWork.Account.GetAll().FirstOrDefault();
            examHistoryVM.exam_Histories = _unitoWork.ExamHistory.GetAll(includeProperties: "Examination").Where(p=>p.Email_User == examHistoryVM.account.Email_User).OrderBy(p => p.DateDoExam);
            return View(examHistoryVM);
        }
    }
}