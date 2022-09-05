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
            IEnumerable<Examination_CategoryVM> examination_CategoryVMs = new List<Examination_CategoryVM>();
            var a = _context.Questions.GroupBy(s => s.Id_Question_Bank);
            //IQueryable<Examination_CategoryVM> examination_CategoryVMs = (IQueryable<Examination_CategoryVM>)_context.Question_Banks.Select(p=> p);
            foreach(var item in examination_CategoryVMs)
            {
                //item.questionbank = _context.Question_Banks.Fi
                item.count = 0;
                foreach (var q in _context.Questions)
                {
                    if (item.questionbank.Id == q.Id_Question_Bank)
                    {
                        item.count++;
                    }
                }
            }
            return examination_CategoryVMs.ToList();
        }
    }
}
