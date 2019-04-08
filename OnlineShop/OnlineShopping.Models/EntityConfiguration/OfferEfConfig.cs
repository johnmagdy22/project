using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Models.Entities;

namespace OnlineShopping.Models.EntityConfiguration
{
    public class OfferEfConfig : EntityTypeConfiguration<Offer>
    {
        public OfferEfConfig()
        {
            this.HasKey(p => p.Id)
                .HasRequired(p => p.Product)
                .WithMany(p => p.Offers)
                .HasForeignKey(p => p.ProductId);

            this.Property(p => p.Value).HasPrecision(16, 2);

            this.Property(p => p.Description).IsRequired();
            this.Property(p => p.Type).IsRequired();
            this.Property(p => p.CreatedOn).IsRequired();
            this.Property(p => p.ValidUntil).IsRequired();

        }
    }
}
