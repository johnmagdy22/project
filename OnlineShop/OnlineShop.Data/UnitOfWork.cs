#region Usings

using System;
using System.Data.Entity;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces.Repositories;

#endregion

namespace OnlineShop.Data
{
    public class UnitOfWork : IDisposable
    {
        public readonly DbContext _ctx;

        public UnitOfWork(DbContext ctx)
        {
            _ctx = ctx;
        }

        public IProductRepository Products => new ProductRepository(_ctx);
        public ICategoryRepository Categories => new CategoryRepository(_ctx);
        public IOrderItemRepository OrderItems => new OrderItemRepository(_ctx);
        public IOrderRepository Orders => new OrderRepository(_ctx);
        public IOfferRepository Offers => new OfferRepository(_ctx);

        public int Complete()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}