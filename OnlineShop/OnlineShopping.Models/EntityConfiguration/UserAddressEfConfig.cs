using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Models.Entities;

namespace OnlineShopping.Models.EntityConfiguration
{
    public class UserAddressEfConfig : EntityTypeConfiguration<UserAddress>
    {
        public UserAddressEfConfig()
        {
            this.HasKey(p => p.Id);

            this.HasRequired(p => p.User)
                .WithMany(p => p.UserAddresses)
                .HasForeignKey(p => p.UserId);

            this.HasMany(p => p.Orders)
                .WithRequired(p => p.DestinationAddress);

            this.Property(p => p.Address).IsRequired();

        }
    }
}
