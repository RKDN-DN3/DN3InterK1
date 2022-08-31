using Quiz.Database.Data;
using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public class ExaminationRepository : Repository<Examination>, IExaminationRepository
    {
        private readonly ApplicationDBContext _context;

        public ExaminationRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}