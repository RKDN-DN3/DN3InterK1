using Quiz.Database.Data;

namespace Quiz.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        public IAccountRepository Account { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Account = new AccountRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}