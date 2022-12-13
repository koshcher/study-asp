using OwnAuth.Context;
using OwnAuth.Models;
using OwnAuth.Services;
using System.Linq;
using System.Web.Mvc;

namespace OwnAuth.Controllers
{
  public class AuthController : Controller
  {
    private readonly OwnAuthDbContext _db = new OwnAuthDbContext();

    [HttpGet]
    public ActionResult Login()
    {
      return View();
    }

    [HttpGet]
    public ActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Register(RegisterModel data, string ConfirmPassword)
    {
      try
      {
        if (ConfirmPassword != data.Password) return View("Register");
        _db.Users.Add(new User
        {
          Email = data.Email,
          Nickname = data.Nickname,
          Password = Hasher.HashPassword(data.Password),
        });
        _db.SaveChanges();
        return View("Login");
      }
      catch
      {
        return View("Register");
      }
    }

    [HttpPost]
    public ActionResult Login(LoginModel data)
    {
      try
      {
        var user = _db.Users.FirstOrDefault(u => u.Nickname == data.Nickname);
        ViewBag.Message = Hasher.VerifyHashedPassword(user.Password, data.Password) ? "Success" : "Failed: password is wrong";
        return View("LoginResult");
      }
      catch
      {
        return View("Login");
      }
    }
  }
}