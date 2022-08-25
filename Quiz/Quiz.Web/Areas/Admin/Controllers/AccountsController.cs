using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Models;
using System.Diagnostics;

namespace Quiz.Web.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;

        public AccountsController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }
        public IActionResult Index()
        {
            AccountsVM accountsVM = new AccountsVM();
            accountsVM.accounts = _unitoWork.Account.GetAll().OrderBy(p => p.CreateDate);
            return View(accountsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AccountsVM vM = new AccountsVM();

            return View(vM);
        }

        [HttpPost]
        public IActionResult Create(AccountsVM vM)
        {
            if (ModelState.IsValid)
            {
                _unitoWork.Account.Add(vM.account);
                _unitoWork.Save();
                return RedirectToAction("Index");
            }
            return BadRequest(ModelState);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}