using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public interface IQuestionBankRepository : IRepository<Question_Bank>
    {
        void Add(Question_Bank question_Bank);

        void Update(Question_Bank question_Bank);

        void Delete(Question_Bank question_Bank);
    }
}