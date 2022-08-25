using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace Quiz.Web.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment mxHostingEnvironment { get; set; }

        public AccountController(IUnitOfWork unitoWork, ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _unitoWork = unitoWork;
            mxHostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            AccountVM accountsVM = new AccountVM();
            accountsVM.accounts = _unitoWork.Account.GetAll();
            return View(accountsVM);
        }
    }
}