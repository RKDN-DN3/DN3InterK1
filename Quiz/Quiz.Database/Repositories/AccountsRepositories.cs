using Quiz.Database.Data;
using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Database.Repositories
{
    public class AccountsRepositories : Repository<Accounts>, IAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public AccountsRepositories(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Accounts accounts)
        {
            var entity = _context.Accounts.FirstOrDefault(x => x.Email_User == accounts.Email_User);
            if (entity != null)
            {
                entity.UserUpdate = accounts.UserUpdate;
                entity.UpdateDate = DateTime.Now;
            }

        }
    }
}
