using System.Collections.Generic;

namespace CarManager.Context.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserCar> UserCars { get; set; }

        public Manager Manager { get; set; }
    }
}