using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Enum;
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
            accountsVM.accounts = _unitoWork.Account.GetAll().Where(p=>p.IsDelete == "0").OrderBy(p => p.CreateDate);
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



        [HttpGet]
        public IActionResult Edit(string? id)
        {
            AccountsVM vM = new AccountsVM();
            if (id != null && vM.account != null)
            {
                vM.account = _unitoWork.Account.GetT(x => x.Email_User == id);
                return View(vM);
            }
            else
            {
                return NotFound();
            }

            if (id == null) { return View(vM); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string? id, AccountsVM vM)
        {
            if (id != vM.account.Email_User)
            {
                return NotFound();
            }
            string a = vM.account.Password;
            string b = vM.account.Name;
            vM.account.UpdateDate = DateTime.Now;
            _unitoWork.Account.Update(vM.account);
            _unitoWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string? id)
        {
            AccountsVM vM = new AccountsVM();
            if (id == null)
            {
                return NotFound();
            }
            vM.account = _unitoWork.Account.GetT(x => x.Email_User == id);
            if (vM.account != null)
            {
                return View(vM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost ]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(string? id)
        {
            AccountsVM vM = new AccountsVM();
            vM.account = _unitoWork.Account.GetT(x => x.Email_User == id);
            if (vM.account == null)
            {
                return NotFound();
            }
            vM.account.IsDelete =Convert.ToString(EnumDelFlag.delete);

            _unitoWork.Account.Update(vM.account);
            _unitoWork.Save();
            TempData["success"] = "Account delete done!";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}