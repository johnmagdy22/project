#region Usings

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineShop.Repositories.Interfaces.Repositories;

#endregion

namespace OnlineShop.Repositories
{
    public class Repository<T> : IRepository<T> where T : class

    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _set;

        public Repository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _set;
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        public T GetById(params object[] key)
        {
            return _set.Find(key);
        }

        public T Add(T entity)
        {
            return _set.Add(entity);
        }

        public void Update(T entity)
        {
            _set.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(params object[] key)
        {
            _set.Remove(GetById(key));
        }
    }
}