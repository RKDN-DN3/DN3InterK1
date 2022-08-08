using Microsoft.EntityFrameworkCore;
using Quiz.Database.Data;
using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Database.Repositories
{
    public class QuestionRepository<T> : Repository<Question>, IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;

        }
    }
}
