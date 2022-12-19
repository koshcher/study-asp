using CarManager.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CarManager.Context.Repository
{
    public class UserRepository : ARepository<User>
    {
        public void Add(User entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var u = _db.Users.Find(id);
            if (u != null)
            {
                _db.Users.Remove(u);
                _db.SaveChanges();
            }
        }

        public User Get(int id)
        {
            return _db.Users
                .Include(u => u.Manager)
                .Include(nameof(User.UserCars))
                .FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetByCondition(Expression<Func<User, bool>> predicate)
        {
            return _db.Users.Where(predicate)
                .Include(nameof(User.UserCars))
                .ToList();
        }

        public void Update(User entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}