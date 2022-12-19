using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManager.Context.Models
{
    public class UserCar
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        public User User { get; set; }

        [Key, Column(Order = 1)]
        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}