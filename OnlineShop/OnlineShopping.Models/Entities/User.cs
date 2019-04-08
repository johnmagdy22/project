#region Usings

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

#endregion

namespace OnlineShopping.Models.Entities
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public class User : ApplicationUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        #region Foreign keys and Navigation

        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        #endregion
    }
}