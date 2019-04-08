#region Usings

using System.Data.Entity;
using OnlineShop.Repositories.Interfaces.Repositories;
using OnlineShopping.Models.Entities;

#endregion

namespace OnlineShop.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}