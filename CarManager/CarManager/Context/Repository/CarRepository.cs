using CarManager.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CarManager.Context.Repository
{
    public class CarRepository : ARepository<Car>
    {
        public void Add(Car entity)
        {
            _db.Cars.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = _db.Cars.Find(id);
            if (c != null)
            {
                _db.Cars.Remove(c);
                _db.SaveChanges();
            }
        }

        public Car Get(int id)
        {
            return _db.Cars.Include(nameof(Car.Manager)).FirstOrDefault(u => u.Id == id);
        }

        public List<Car> GetByCondition(Expression<Func<Car, bool>> predicate)
        {
            return _db.Cars.Where(predicate).ToList();
        }

        public List<Car> GetByConditions(List<Expression<Func<Car, bool>>> predicates)
        {
            IQueryable<Car> cars = _db.Cars;

            foreach (var predicate in predicates)
            {
                cars = cars.Where(predicate);
            }
            return cars.Include(nameof(Car.Manager)).ToList();
        }

        public void Update(Car entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}