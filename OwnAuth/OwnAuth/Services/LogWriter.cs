using OwnAuth.Models;
using System;
using System.IO;

namespace OwnAuth.Services
{
  public class LogWriter
  {
    private readonly string dir;

    public LogWriter()
    {
      dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ownauth", "auth");

      if (!Directory.Exists(dir))
      {
        Directory.CreateDirectory(dir);
      }
    }

    public void Register(RegisterModel data)
    {
      File.AppendAllText(Path.Combine(dir, "register.txt"), $"{data.Nickname} {data.Email} {data.Password}\n");
    }

    public void Login(LoginModel data)
    {
      File.AppendAllText(Path.Combine(dir, "login.txt"), $"{data.Nickname} {data.Password}\n");
    }
  }
}