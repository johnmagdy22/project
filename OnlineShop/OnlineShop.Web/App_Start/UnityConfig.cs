using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using OnlineShop.Data;
using OnlineShop.Web.Controllers;
using OnlineShopping.Models.Entities;

namespace OnlineShop.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<UnitOfWork>();
            
            container.RegisterType<UserManager<User>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<User>, UserStore<User>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(
                new InjectionConstructor());
            container.RegisterType<ManageController>(
                new InjectionConstructor());
        }
    }
}
