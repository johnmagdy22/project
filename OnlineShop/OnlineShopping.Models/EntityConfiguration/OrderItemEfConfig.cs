using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Models.Entities;

namespace OnlineShopping.Models.EntityConfiguration
{
    public class OrderItemEfConfig : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemEfConfig()
        {
            this.HasKey(p => p.Id);

            this.HasRequired(p => p.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.ProductId);

            this.HasRequired(p => p.Order)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.OrderId);
        }   
    }
}
