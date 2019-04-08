#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace OnlineShopping.Models.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        #region Foreign keys and Navigation

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion
    }
}