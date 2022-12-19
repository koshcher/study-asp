using CarManager.Helper;
using System.Web.Mvc;

namespace CarManager.Filters
{
    public class ManagerFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Identity.User.Manager == null)
            {
                filterContext.Result = new RedirectResult("Home");
            }
        }
    }
}