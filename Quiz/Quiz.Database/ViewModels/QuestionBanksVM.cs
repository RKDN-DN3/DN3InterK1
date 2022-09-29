using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Entities;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Database.ViewModels
{
    public class QuestionBanksVM
    {
        public Question_Bank questionbank { get; set; } = new Question_Bank();

        public IEnumerable<Question_Bank> questionbanks { get; set; } = new List<Question_Bank>();

        public string? Search_Content { get; set; }
    }
}