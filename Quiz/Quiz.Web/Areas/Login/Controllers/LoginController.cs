using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Entities;
using Quiz.Web.Controllers;

namespace Quiz.Web.Controllers
{
    [Area("Login")]
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;
        //private UserManager<TUser> userManager;

        public LoginController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            ForgotPWVM vM = new ForgotPWVM();
            return View(vM);
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> ForgotPassword(ForgotPWVM vM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(vM.Email);
        //        if(user == null && await userManager.IsEmailConfirmedAsync(user))
        //        {
        //            var token = await userManager.GeneratePasswordResetTokenAsync(user);

        //            var PasswordResetLink = Url.Action("Reset Password", "Login", new { email = vM.Email, token = token },
        //            Request.Scheme);

        //            _logger.Log(LogLevel.Warning, PasswordResetLink);

        //            return View("ForgotPasswordConfirm");
        //        }
        //        return View("ForgotPasswordConfirm");
        //    }
        //    return BadRequest(ModelState);
        //}
        [HttpGet]
        public IActionResult Index()
        {
            LoginVM vM = new LoginVM();
            try
            {
                // Verification.  
                if (this.User.Identity.IsAuthenticated)
                {
                    // Home Page.  
                    return this.Redirect("/Admin/Home/Index");
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            //return this.Page();
            return View(vM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginVM vM)
        {
            if (ModelState.IsValid)
            {
                // Initialization.  
                //var loginInfo = await this._unitoWork.
                //    _unitoWork.LoginByUsernamePasswordMethodAsync(this.LoginModel.Username, this.LoginModel.Password);

                Accounts acc = _unitoWork.Account.GetT(x => x.Email_User == vM.Email_User && x.IsDelete =="0");
                if(acc != null)
                {
                    if(acc.Password == vM.Password)
                    {
                        if (acc.Authority == "0")
                        {
                            return Redirect("/Admin/Home/Index"); //HomePageAdmin
                        }
                        else if (acc.Authority == "1")
                        {
                            return Redirect("/User/Home/Index"); //HomePageUser

                        }
                    }
                    else
                    {
                        //sai pw
                        vM.FlagCheckPW = "0";
                        return View(vM);
                    }
                }   
                else
                {
                    //email khong ton tai
                    vM.FlagCheckEmail = "0";
                    return View(vM);
                }    
            }
            return BadRequest(ModelState);
        }

    }
}