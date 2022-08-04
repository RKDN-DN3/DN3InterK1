using Microsoft.AspNetCore.Mvc;
using Quiz.Database.Repositories;
using Quiz.Database.ViewModels;
using Quiz.Web.Models;
using System.Diagnostics;

namespace Quiz.Web.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQuestionRepository _repository;

        public QuestionController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //TODO: injection repository
            //_repository = new QuestionRepository(_context);
        }

        public IActionResult Index()
        {
            QuestionsVM questionsVM = new QuestionsVM();
            questionsVM.questions = _repository.GetAll();
            return View(questionsVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}