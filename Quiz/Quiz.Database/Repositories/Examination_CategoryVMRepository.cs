using Quiz.Database.Data;
using Quiz.Database.ViewModels;

namespace Quiz.Database.Repositories
{
    public class Examination_CategoryVMRepository : IExamination_CategoryVMRepository
    {
        private readonly ApplicationDBContext _context;

        public Examination_CategoryVMRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        IEnumerable<Examination_CategoryVM> IExamination_CategoryVMRepository.GetAll()
        {
            var v = (from questionbank in _context.Question_Banks.Where(p => p.IsDelete == "0")
                     join question in _context.Questions.Where(q=>q.IsDelete == "0")
                     on questionbank.Id equals question.Id_Question_Bank into questionsInQuestionBank
                     from que in questionsInQuestionBank.DefaultIfEmpty()
                     select new Examination_CategoryVM
                     {
                         questionbank = questionbank,
                         count = questionsInQuestionBank.Count()
                     }).AsEnumerable();
            return v;
        }
    }
}
