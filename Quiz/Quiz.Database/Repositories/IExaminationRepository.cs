using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public interface IExaminationRepository : IRepository<Examination>
    {
        void Add(Examination examination);

        void Update(Examination examination);

        void Delete(Examination examination);
    }
}