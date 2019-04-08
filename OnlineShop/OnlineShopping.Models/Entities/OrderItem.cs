#region Usings

using System;

#endregion

namespace OnlineShopping.Models.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public short Quantity { get; set; }

        #region Foreign keys and Navigation
        
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
        
        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        #endregion
    }
}