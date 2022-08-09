using Quiz.Database.Data;
using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public class QuestionRepository<T> : Repository<Question>, IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;

        }
    }
}
