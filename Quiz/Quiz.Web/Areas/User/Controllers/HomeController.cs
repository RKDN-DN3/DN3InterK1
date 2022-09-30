using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;

namespace Quiz.Web.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitoWork;
        public HomeController(IUnitOfWork unitoWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitoWork = unitoWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
