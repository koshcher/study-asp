using CarManager.Context.Models;
using CarManager.Context.Repository;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Services
{
    public class AuthService
    {
        private readonly UserRepository users = UnityConfig.Resolver.GetService<UserRepository>();

        public User Login(string email, string password)
        {
            return users.GetByCondition(u => u.Password == password && u.Email == email).FirstOrDefault();
        }

        public User Register(User user, bool isManager)
        {
            if (users.GetByCondition(u => u.Email == user.Email).FirstOrDefault() != null) return null;
            if (isManager) user.Manager = new Manager { Id = user.Id };
            users.Add(user);
            return user;
        }
    }
}