#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace OnlineShopping.Models.Entities
{
    public enum OrderStatus
    {
        New = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4
    }

    public class Order
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }

        #region Foreign keys and Navigation

        public Guid DestinationAddressId { get; set; }
        public UserAddress DestinationAddress { get; set; }
        
        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        #endregion
    }
}