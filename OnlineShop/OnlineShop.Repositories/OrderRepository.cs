#region Usings

using System.Data.Entity;
using OnlineShop.Repositories.Interfaces.Repositories;
using OnlineShopping.Models.Entities;

#endregion

namespace OnlineShop.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}