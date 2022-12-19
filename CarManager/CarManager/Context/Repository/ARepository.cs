using System.Web.Mvc;

namespace CarManager.Context.Repository
{
    public abstract class ARepository<T> where T : class
    {
        protected CarManagerDbContext _db = UnityConfig.Resolver.GetService<CarManagerDbContext>();
    }
}