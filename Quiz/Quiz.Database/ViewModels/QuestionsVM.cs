using Quiz.Entities;

namespace Quiz.Database.ViewModels
{
    public class QuestionsVM
    {
        public Question question { get; set; } = new Question();

        public IEnumerable<Question> questions { get; set; } = new List<Question>();

        public IEnumerable<Question_Bank> question_Banks { get; set; } = new List<Question_Bank>();
    }
}
