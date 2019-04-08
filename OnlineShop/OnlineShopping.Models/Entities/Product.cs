#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace OnlineShopping.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short InStock { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        #region Foreign keys and Navigation
        
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

        #endregion
    }
}