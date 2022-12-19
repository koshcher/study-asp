using System.Collections.Generic;

namespace CarManager.Context.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Num { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public bool Secondhand { get; set; }

        public Manager Manager { get; set; }
        public int ManagerId { get; set; }

        public ICollection<UserCar> UserCars { get; set; }
    }
}