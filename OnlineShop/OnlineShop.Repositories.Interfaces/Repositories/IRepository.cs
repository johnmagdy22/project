#region Usings

using System.Collections.Generic;
using System.Linq;

#endregion

namespace OnlineShop.Repositories.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQueryable();
        T GetById(params object[] key);
        T Add(T entity);
        void Update(T entity);
        void Delete(params object[] key);
    }
}