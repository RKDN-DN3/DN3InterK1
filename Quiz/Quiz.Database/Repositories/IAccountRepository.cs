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
        void Add( Accounts accounts);
        void Update(Accounts accounts);
        void Delete(Accounts accounts);
    }
}
