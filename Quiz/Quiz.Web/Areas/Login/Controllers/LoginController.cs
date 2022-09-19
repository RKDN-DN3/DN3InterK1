using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Controllers;

namespace Quiz.Web.Controllers
{
    [Area("Login")]
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;

        public LoginController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            AccountsVM vM = new AccountsVM();
            vM.accounts = _unitoWork.Account.GetAll().Where(p => p.IsDelete == "0");
            return View(vM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AccountsVM vM)
        {
            if (!ModelState.IsValid) return Index();

            //vM.question.ImageUrl = ProcessUploadedFile(vM);
            //vM.question.Id = Guid.NewGuid();
            //vM.question.IsDelete = ConstQuiz.IsDelete_None;

            //_unitoWork.Question.Add(vM.question);
            _unitoWork.Save();
            return RedirectToAction("Index");
        }
    }
}