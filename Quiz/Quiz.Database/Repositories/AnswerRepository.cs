using Quiz.Database.Data;
using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        private readonly ApplicationDBContext _context;

        public AnswerRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}