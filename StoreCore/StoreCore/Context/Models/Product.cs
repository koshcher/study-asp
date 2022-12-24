namespace StoreCore.Context.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public int? UnitPrice { get; set; }
        public double? Weight { get; set; }

        public List<OrderDetails> OrderDetails { get; set;}
    }
}
