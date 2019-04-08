#region Usings

using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Data;
using OnlineShopping.Models.Entities;

#endregion

namespace OnlineShop.Web
{
    public class UserAndRoleHelper
    {
        private static readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        public static void AddInitialUsersAndRoles()
        {
            // we need RoleStore, RoleManager, UserStore, UserManager
            var roleStore = new RoleStore<IdentityRole>(_ctx);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<User>(_ctx);
            var userManager = new UserManager<User>(userStore);

            if (!roleManager.RoleExists("Customer"))
                roleManager.Create(new IdentityRole("Customer"));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));
            if (!roleManager.RoleExists("Sales"))
                roleManager.Create(new IdentityRole("Sales"));

            var admin = new User
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Other
            };

            var sales = new User
            {
                UserName = "sales@sales.com",
                Email = "sales@sales.com",
                DateOfBirth = DateTime.Now,
                Gender = Gender.Other
            };

            if (userManager.FindByEmail("admin@admin.com") == null)
            {
                userManager.Create(admin,"TestTest1!");
                userManager.AddToRole(admin.Id, "Admin");
            }

            if (userManager.FindByEmail("sales@sales.com") == null)
            {
                userManager.Create(sales, "TestTest1!");
                userManager.AddToRole(sales.Id, "Sales");
            }
        }
    }
}