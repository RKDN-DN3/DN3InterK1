using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Database.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        void Add(Question question);
        void Update(Question question);
        void Delete(Question question);
    }
}
