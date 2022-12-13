namespace OwnAuth.Models
{
  public class LoginModel
  {
    public string Nickname { get; set; }
    public string Password { get; set; }
  }

  public class RegisterModel : LoginModel
  {
    public string Email { get; set; }
  }

  public class User : RegisterModel
  {
    public int Id { get; set; }
  }
}