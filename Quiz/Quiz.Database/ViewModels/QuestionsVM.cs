using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Entities;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Database.ViewModels
{
    public class QuestionsVM
    {
        public Question question { get; set; } = new Question();
        public IFormFile? File { get; set; }

        public IEnumerable<Question> questions { get; set; } = new List<Question>();

        public IEnumerable<Question_Bank> question_Banks { get; set; } = new List<Question_Bank>();

        public string? ExistingImage { get; set; }
    }
}