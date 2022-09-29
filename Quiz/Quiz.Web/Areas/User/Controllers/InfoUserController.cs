using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Controllers;

namespace Quiz.Web.Areas.User.Controllers
{
    [Area("User")]
    public class InfoUserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;

        public InfoUserController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }
        public IActionResult Index()
        {
            AccountsVM vM = new AccountsVM();
            vM.account = _unitoWork.Account.GetAll().Where(p => p.Email_User == "thanhnq@gmail.com").FirstOrDefault();
            
            return View(vM);
        }
    }

}
