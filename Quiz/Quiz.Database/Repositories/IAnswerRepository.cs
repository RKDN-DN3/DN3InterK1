using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        void Add(Answer answer);

        void Update(Answer answer);

        void Delete(Answer answer);
    }
}