using Quiz.Entities;

namespace Quiz.Database.ViewModels
{
    public class ExaminationVM
    {
        public IEnumerable<Examination_CategoryVM> Examination_CategoryVMs { get; set; }

        public Examination examination { get; set; } = new Examination();
        public Examination_Detail examination_Detail { get; set; } = new Examination_Detail();

        public IEnumerable<Question> questions { get; set; } = new List<Question>();

        public IEnumerable<Question_Bank> question_Banks { get; set; } = new List<Question_Bank>();

        public IEnumerable<Examination_Detail> examination_Details { get; set; } = new List<Examination_Detail>();

        public IEnumerable<List_Question_In_Exam> list_Question_In_Exams { get; set; } = new List<List_Question_In_Exam>();
    }
}