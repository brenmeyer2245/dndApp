using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using DnDApp.Services;
using DnDApp.Repositories;

namespace DnDApp.App_Start.Config
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IBookRepository, EFBookRepository>(new Unity.Lifetime.HierarchicalLifetimeManager());
            container.RegisterType<IBookService, EFBookService>(new Unity.Lifetime.HierarchicalLifetimeManager());
            container.RegisterType<ICharacterRepository, EFCharacterRepository>(new Unity.Lifetime.HierarchicalLifetimeManager());
            container.RegisterType<ICharacterService, EFCharacterService>(new Unity.Lifetime.HierarchicalLifetimeManager());
            container.RegisterType<IEpisodeRepository, EFEpisodeRepository>(new Unity.Lifetime.HierarchicalLifetimeManager());
            container.RegisterType<IEpisodeService, EFEpisodeService>(new Unity.Lifetime.HierarchicalLifetimeManager());

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}