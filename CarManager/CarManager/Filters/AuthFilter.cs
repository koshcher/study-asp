using CarManager.Helper;
using System.Web.Mvc;

namespace CarManager.Filters
{
    public class AuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Identity.User == null)
            {
                filterContext.Result = new RedirectResult("Auth/Login");
            }
        }
    }
}