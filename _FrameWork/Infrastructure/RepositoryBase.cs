using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using _Framework.Domain;

using Microsoft.EntityFrameworkCore;

namespace _Framework.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
           await _context.AddAsync(entity);
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
          return await  _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> Get(TKey id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
