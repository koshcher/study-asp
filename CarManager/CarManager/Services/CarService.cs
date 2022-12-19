using CarManager.Context.Models;
using CarManager.Context.Repository;
using CarManager.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CarManager.Services
{
    public class CarService
    {
        private readonly CarRepository _repo = UnityConfig.Resolver.GetService<CarRepository>();

        public void Add(Car car) => _repo.Add(car);

        public void Update(Car car)
        {
            _repo.Update(car);
        }

        public void Delete(int id) => _repo.Delete(id);

        public void Get(int id) => _repo.Get(id);

        public List<Car> GetAll()
        {
            return GetByCondition(c => true);
        }

        public List<Car> GetByCondition(Expression<Func<Car, bool>> predicate)
        {
            return _repo.GetByCondition(predicate);
        }

        public List<Car> Filter(FilterModel filter)
        {
            List<Expression<Func<Car, bool>>> predicates = new List<Expression<Func<Car, bool>>>();

            if (filter.State == SecondhandState.New)
            {
                predicates.Add(c => c.Secondhand == false);
            }
            else if (filter.State == SecondhandState.Secondhand)
            {
                predicates.Add(c => c.Secondhand == true);
            }

            if (!filter.Name.IsEmpty()) predicates.Add(c => c.Name.StartsWith(filter.Name));
            if (!filter.Model.IsEmpty()) predicates.Add(c => c.Model.StartsWith(filter.Model));
            if (!filter.Color.IsEmpty()) predicates.Add(c => c.Color.StartsWith(filter.Color));
            if (filter.Num != null) predicates.Add(c => c.Num == filter.Num);
            if (filter.Year != null) predicates.Add(c => c.Year == filter.Year);

            return _repo.GetByConditions(predicates);
        }
    }
}