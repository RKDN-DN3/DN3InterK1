using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Entities;

namespace Quiz.Database.ViewModels
{
    public class QuestionsVM
    {
        public Question question { get; set; } = new Question();
        public IFormFile? File { get; set; }

        public IEnumerable<Question> questions { get; set; } = new List<Question>();

        public List<SelectListItem>? QuestionBanks { set; get; }

        public string? ExistingImage { get; set; }

        public IEnumerable<Answer> answers{ get; set; } = new List<Answer>();

    }
}