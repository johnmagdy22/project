using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Models.Entities;

namespace OnlineShopping.Models.EntityConfiguration
{
    public class ProductEfConfig : EntityTypeConfiguration<Product>
    {
        public ProductEfConfig()
        {
            this.HasKey(p => p.Id);

            this.HasRequired(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

            this.HasMany(p => p.OrderItems)
                .WithRequired(p => p.Product);

            this.HasMany(p => p.Offers)
                .WithRequired(p => p.Product);

            this.Property(p => p.Name).IsRequired();
            this.Property(p => p.Description).IsRequired();
            this.Property(p => p.Image).IsRequired();

        }
    }
}
