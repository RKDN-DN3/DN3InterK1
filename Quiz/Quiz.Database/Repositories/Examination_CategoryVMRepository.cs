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
            var v = (from questionbank in _context.Question_Banks
                     join question in _context.Questions
                     on questionbank.Id equals question.Id_Question_Bank into data_1 //Bug Group
                     from que in data_1.DefaultIfEmpty()
                     select new
                     {
                         questionbank = questionbank,
                         count = data_1.Count()
                     }).AsEnumerable();
            foreach(var item in v)                                       
            {
                Console.WriteLine(item.questionbank.Name + item.count);
            }

            return (IEnumerable<Examination_CategoryVM>)v.ToList();
        }
    }
}
