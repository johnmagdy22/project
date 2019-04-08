#region Usings

using System.Data.Entity;
using OnlineShop.Repositories.Interfaces.Repositories;
using OnlineShopping.Models.Entities;

#endregion

namespace OnlineShop.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}