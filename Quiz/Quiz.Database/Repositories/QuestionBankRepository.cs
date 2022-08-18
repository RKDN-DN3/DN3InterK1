using Quiz.Database.Data;
using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public class QuestionBankRepository : Repository<Question_Bank>, IQuestionBankRepository
    {
        private readonly ApplicationDBContext _context;

        public QuestionBankRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}