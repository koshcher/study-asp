using CarManager.Filters;
using System.Web.Mvc;

namespace CarManager
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      filters.Add(new InitUserFilter());
    }
  }
}