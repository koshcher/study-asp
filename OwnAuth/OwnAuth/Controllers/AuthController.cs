using OwnAuth.Models;
using OwnAuth.Services;
using System.Web.Mvc;

namespace OwnAuth.Controllers
{
  public class AuthController : Controller
  {
    private readonly LogWriter logger = new LogWriter();

    public ActionResult Login()
    {
      return View();
    }

    public ActionResult Register()
    {
      return View();
    }

    public ActionResult NewRegister(RegisterModel data, string ConfirmPassword)
    {
      try
      {
        if (ConfirmPassword != data.Password) return View("Register");
        logger.Register(data);
        return View("Login");
      }
      catch
      {
        return View("Register");
      }
    }

    public ActionResult NewLogin(LoginModel data)
    {
      try
      {
        logger.Login(data);
        return Redirect("/");
      }
      catch
      {
        return View("Login");
      }
    }
  }
}