using CarManager.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CarManager.Context.Repository
{
    public class ManagerRepository : ARepository<Manager>
    {
        public void Add(Manager entity)
        {
            _db.Managers.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var m = _db.Managers.Find(id);
            if (m != null)
            {
                _db.Managers.Remove(m);
                _db.SaveChanges();
            }
        }

        public Manager Get(int id)
        {
            return _db.Managers.Include(nameof(Manager.Cars)).FirstOrDefault(m => m.Id == id);
        }

        public List<Manager> GetByCondition(Expression<Func<Manager, bool>> predicate)
        {
            return _db.Managers.Where(predicate).Include(nameof(Manager.Cars)).ToList();
        }

        public void Update(Manager entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}