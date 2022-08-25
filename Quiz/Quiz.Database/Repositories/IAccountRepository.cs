using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Database.Repositories
{
    public interface IAccountRepository : IRepository<Accounts>
    {
        void Add(Accounts account);

        void Update(Accounts account);

        void Delete(Accounts account);
    }
}
