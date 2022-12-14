using CarManager.Context;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace CarManager
{
  public static class UnityConfig
  {
    public static UnityDependencyResolver Resolver { get; set; }

    public static void RegisterComponents(string connectionString)
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      container.RegisterType<CarManagerDbContext, CarManagerDbContext>(new InjectionConstructor(connectionString));
      Resolver = new UnityDependencyResolver(container);
      DependencyResolver.SetResolver(Resolver);
    }
  }
}