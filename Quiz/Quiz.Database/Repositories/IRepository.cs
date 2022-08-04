using System.Linq.Expressions;

namespace Quiz.Database.Repositories
{
    public interface IRepository<T> where T : class
    {
        //x=>x.id==id, _context.question.include("").toList();
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        T GetT(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
