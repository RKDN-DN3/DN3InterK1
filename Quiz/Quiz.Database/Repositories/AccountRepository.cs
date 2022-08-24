using Quiz.Database.Data;
using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public class AccountRepository : Repository<Accounts>, IAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public AccountRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Accounts account)
        {
            var entity = _context.Accounts.FirstOrDefault(x => x.Email_User == account.Email_User);
            if (entity != null)
            {
                entity.UserUpdate = account.UserUpdate;
                entity.UpdateDate = DateTime.Now;
            }
        }
    }
}