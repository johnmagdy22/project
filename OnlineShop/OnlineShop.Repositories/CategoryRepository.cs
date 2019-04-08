#region Usings

using System.Data.Entity;
using OnlineShop.Repositories.Interfaces.Repositories;
using OnlineShopping.Models.Entities;

#endregion

namespace OnlineShop.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}