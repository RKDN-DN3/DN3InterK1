using Quiz.Database.Data;

namespace Quiz.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        public IQuestionRepository Question { get; private set; }
        public IQuestionBankRepository Question_Bank { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Question = new QuestionRepository(context);
            Question_Bank = new QuestionBankRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
