using CarManager.Context.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarManager.Context.Repository
{
    public class UserCarRepository : ARepository<UserCar>
    {
        public List<UserCar> GetByUserId(int userId)
        {
            return _db.UserCars.Include(nameof(UserCar.Car)).Where(uc => uc.UserId == userId).ToList();
        }

        public void Add(UserCar entity)
        {
            _db.UserCars.Add(entity);
            _db.SaveChanges();
        }

        public void Remove(int userId, int carId)
        {
            var userCar = _db.UserCars.FirstOrDefault(uc => uc.UserId == userId && uc.CarId == carId);
            if (userCar != null)
            {
                _db.UserCars.Remove(userCar);
                _db.SaveChanges();
            }
        }
    }
}