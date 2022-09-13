using Quiz.Entities;

namespace Quiz.Database.ViewModels
{
    public class ExaminationVM
    {
        public Accounts account { get; set; } = new Accounts();
        public Examination examination { get; set; } = new Examination();
        public IEnumerable<Examination> examinations { get; set; } = new List<Examination>();
    }
}