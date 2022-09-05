using Quiz.Database.Data;

namespace Quiz.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        public IQuestionRepository Question { get; private set; }

        public IQuestionBankRepository QuestionBank { get; private set; }

        public IAccountRepository Account { get; private set; }

        public IExaminationRepository Examination { get; private set; }

        public IExamination_CategoryVMRepository Examination_CategoryVM { get; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Question = new QuestionRepository(context);
            QuestionBank = new QuestionBankRepository(context);
            Account = new AccountRepository(context);
            Examination = new ExaminationRepository(context);
            Examination_CategoryVM = new Examination_CategoryVMRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}