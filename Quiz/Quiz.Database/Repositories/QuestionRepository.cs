using Quiz.Database.Data;
using Quiz.Entities;

namespace Quiz.Database.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;

        }

        //public void Update(Question question)
        //{
        //    var entity = _context.Questions.FirstOrDefault(x => x.Id == question.Id);
        //    if (entity != null)
        //    {
        //        entity.UserUpdate = question.UserUpdate;
        //        entity.UpdateDate = DateTime.Now;
        //    }

        //}
    }
}
