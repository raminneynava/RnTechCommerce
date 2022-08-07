using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _Framework.Domain
{
    public interface IRepository<TKey,T> where T: class
    {
        Task<T> Get(TKey id);
        Task<IEnumerable<T>> Get();
        Task Create(T entity);
        Task<bool> Exists(Expression<Func<T,bool>> expression);
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
