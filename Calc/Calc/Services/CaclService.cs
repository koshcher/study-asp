using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calc.Models
{
  public static class CaclService
  {
    public static double Plus(double x, double y)
    {
      return x + y;
    }

    public static double Minus(double x, double y)
    {
      return x - y;
    }

    public static double Multi(double x, double y)
    {
      return x * y;
    }

    public static double Divide(double x, double y)
    {
      if (y == 0)
      {
        throw new Exception("Y can't be 0");
      }
      return x / y;
    }
  }
}