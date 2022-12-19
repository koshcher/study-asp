using CarManager.Context.Models;
using CarManager.Context.Repository;
using CarManager.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarManager.Services
{
    public class CartService
    {
        private readonly UserCarRepository _repo = UnityConfig.Resolver.GetService<UserCarRepository>();

        public List<Car> List()
        {
            return _repo
                .GetByUserId(Identity.User.Id)
                .Select(uc => uc.Car)
                .ToList();
        }

        public void Add(int carId)
        {
            _repo.Add(new UserCar { UserId = Identity.User.Id, CarId = carId });
            // force update of cars
            Identity.User.UserCars = _repo.GetByUserId(Identity.User.Id);
        }

        public void Remove(int carId)
        {
            _repo.Remove(Identity.User.Id, carId);
            // force update of cars
            Identity.User.UserCars = _repo.GetByUserId(Identity.User.Id);
        }
    }
}