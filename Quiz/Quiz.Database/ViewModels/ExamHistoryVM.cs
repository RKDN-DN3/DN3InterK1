using Quiz.Entities;

namespace Quiz.Database.ViewModels
{
    public class ExamHistoryVM
    {
        public Exam_History exam_History { get; set; } = new Exam_History();

        public IEnumerable<Exam_History> exam_Histories { get; set; } = new List<Exam_History>();
    }
}