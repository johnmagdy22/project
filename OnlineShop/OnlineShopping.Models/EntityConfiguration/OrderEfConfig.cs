using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Models.Entities;

namespace OnlineShopping.Models.EntityConfiguration
{
    public class OrderEfConfig : EntityTypeConfiguration<Order>
    {
        public OrderEfConfig()
        {
            this.HasKey(p => p.Id)
                .HasMany(p => p.Items)
                .WithRequired(p => p.Order);

            this.HasRequired(p => p.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.UserId);

            this.HasRequired(p => p.DestinationAddress)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.DestinationAddressId);

            this.Property(p => p.CreatedOn).IsRequired();
            this.Property(p => p.Status).IsRequired();


        }
    }
}
