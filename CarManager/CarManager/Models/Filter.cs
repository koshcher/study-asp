using CarManager.Context.Models;
using System.Collections.Generic;

namespace CarManager.Models
{
    public class FilterViewModel
    {
        public List<Car> Cars { get; set; }

        public List<string> Colors { get; set; }
    }

    public enum SecondhandState
    {
        All,
        New,
        Secondhand
    }

    public class FilterModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int? Num { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public SecondhandState State { get; set; }
    }
}