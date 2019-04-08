using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Models.Entities;

namespace OnlineShopping.Models.EntityConfiguration
{
    public class CategoryEfConfig : EntityTypeConfiguration<Category>
    {
        public CategoryEfConfig()
        {
            this.HasKey(p => p.Id);

            this.HasMany(p => p.Products)
                .WithRequired(p => p.Category);

            this.Property(p => p.Name).IsRequired();
        }
    }
}
