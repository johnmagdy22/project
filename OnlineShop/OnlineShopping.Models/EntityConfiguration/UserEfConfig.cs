using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Models.Entities;

namespace OnlineShopping.Models.EntityConfiguration
{
    public class UserEfConfig : EntityTypeConfiguration<User>
    {
        public UserEfConfig()
        {
            this.HasMany(p => p.UserAddresses)
                .WithRequired(p => p.User)
                .WillCascadeOnDelete(false);

       
            
        }
    }
}
