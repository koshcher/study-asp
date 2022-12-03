using Calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calc.Controllers
{
  public class CalcController : Controller
  {
    private ActionResult FindResult(Func<double, double, double> doMath)
    {
      double x;
      double y;

      try
      {
        x = Convert.ToDouble(RouteData.Values["x"]);
        y = Convert.ToDouble(RouteData.Values["y"]);
      }
      catch
      {
        ViewBag.Result = "Input isn't valid";
        return View("Index");
      }

      try
      {
        ViewBag.Result = doMath(x, y);
      }
      catch (Exception ex)
      {
        ViewBag.Result = ex.Message;
      }

      return View("Index");
    }

    public ActionResult Plus()
    {
      return FindResult(CaclService.Plus);
    }

    public ActionResult Minus()
    {
      return FindResult(CaclService.Minus);
    }

    public ActionResult Multi()
    {
      return FindResult(CaclService.Multi);
    }

    public ActionResult Divide()
    {
      return FindResult(CaclService.Divide);
    }
  }
}