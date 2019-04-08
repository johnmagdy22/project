#region Usings

using System.Data.Entity;
using OnlineShop.Repositories.Interfaces.Repositories;
using OnlineShopping.Models.Entities;

#endregion

namespace OnlineShop.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}