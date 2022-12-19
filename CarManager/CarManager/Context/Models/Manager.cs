using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManager.Context.Models
{
    public class Manager
    {
        // same as user id
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public User User { get; set; }
        public List<Car> Cars { get; set; }
    }
}