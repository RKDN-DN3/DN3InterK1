using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public interface IAccountRepository : IRepository<Accounts>
    {
        void Add(Accounts account);

        void Update(Accounts account);

        void Delete(Accounts account);
    }
}
