using Quiz.Database.Data;
using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public class ExamHistoryRepository : Repository<Exam_History>, IExamHistoryRepository
    {
        private readonly ApplicationDBContext _context;

        public ExamHistoryRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}