using CarManager.Context.Repository;
using CarManager.Helper;
using System.Web.Mvc;

namespace CarManager.Filters
{
    public class InitUserFilter : FilterAttribute, IAuthorizationFilter
    {
        private readonly UserRepository _ur = UnityConfig.Resolver.GetService<UserRepository>();

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies["AuthKey"] != null)
            {
                int userId = int.Parse(filterContext.HttpContext.Request.Cookies["AuthKey"].Value);
                Identity.User = _ur.Get(userId);
            }
        }
    }
}