using CarManager.Context.Models;
using CarManager.Context.Repository;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Services
{
    public class AuthService
    {
        private readonly UserRepository _urepo = UnityConfig.Resolver.GetService<UserRepository>();
        private readonly ManagerRepository _mrepo = UnityConfig.Resolver.GetService<ManagerRepository>();

        public User Login(string email, string password)
        {
            User user = _urepo.GetByCondition(u => u.Password == password && u.Email == email)
                      .FirstOrDefault();
            user.Manager = _mrepo.Get(user.Id);
            return user;
        }

        public User Register(User user, bool isManager)
        {
            var repoUser = _urepo.GetByCondition(u => u.Email == user.Email).FirstOrDefault();

            if (repoUser != null) return null;

            _urepo.Add(user);

            if (isManager)
            {
                _mrepo.Add(new Manager { Id = user.Id });
            }

            return user;
        }

        public User Get(int id) => _urepo.Get(id);
    }
}