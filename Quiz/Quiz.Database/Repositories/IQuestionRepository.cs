using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        void Add(Question question);
        void Update(Question question);
        void Delete(Question question);
    }
}
