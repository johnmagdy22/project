#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace OnlineShopping.Models.Entities
{
    public class UserAddress
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        #region Foreign keys and Navigation
        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        #endregion
    }
}