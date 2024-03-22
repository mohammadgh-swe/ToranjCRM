using System.Linq.Expressions;

namespace ProjectFramework.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        T Get(TKey id);
        List<T> Get();
        void Create(T entity);
        void SaveChanges();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
