using CarManager.Context;
using CarManager.Helper;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Filters
{
  public class InitUserFilter : FilterAttribute, IAuthorizationFilter
  {
    private readonly CarManagerDbContext _db;

    public InitUserFilter()
    {
      _db = UnityConfig.Resolver.GetService<CarManagerDbContext>();
    }

    public void OnAuthorization(AuthorizationContext filterContext)
    {
      if (filterContext.HttpContext.Request.Cookies["AuthKey"] != null)
      {
        int userId = int.Parse(filterContext.HttpContext.Request.Cookies["AuthKey"].Value);
        Identity.User = _db.Users.First(u => u.Id == userId);
      }
    }
  }
}