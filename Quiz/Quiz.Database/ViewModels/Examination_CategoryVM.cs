using Quiz.Entities;

namespace Quiz.Database.ViewModels
{
    public class Examination_CategoryVM
    {
        public Question_Bank questionbank { get; set; } = new Question_Bank();
        public int count;
    }
}
