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

        public void Update(Question_Bank question_bank)
        {
            var entity = _context.Questions.FirstOrDefault(x => x.Id == question_bank.Id);
            if (entity != null)
            {
                entity.UserUpdate = question_bank.UserUpdate;
                entity.UpdateDate = DateTime.Now;
            }
        }
    }
}