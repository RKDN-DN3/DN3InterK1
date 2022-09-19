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

        public IActionResult Index()
        {
            AccountsVM vM = new AccountsVM();
            vM.accounts = _unitoWork.Account.GetAll().Where(p => p.IsDelete == "0");
            return View(vM);
        }
    }
}