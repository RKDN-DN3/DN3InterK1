using Quiz.Database.Data;

namespace Quiz.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        public IQuestionRepository Question { get; private set; }

        public IQuestionBankRepository QuestionBank { get; private set; }

        public IAccountRepository Account { get; private set; }

        public IExamHistoryRepository ExamHistory { get; private set; }

        public IAnswerRepository Answer { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Question = new QuestionRepository(context);
            QuestionBank = new QuestionBankRepository(context);
            Account = new AccountRepository(context);
            ExamHistory = new ExamHistoryRepository(context);
            Answer = new AnswerRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}