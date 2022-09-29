using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        void Add(ApplicationUser account);

        void Update(ApplicationUser account);

        void Delete(ApplicationUser account);
    }
}