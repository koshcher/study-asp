namespace StoreCore.Context.Models
{
    public class OrderDetails
    {
        // Order.Id
        public int Id { get; set; }
        public Order Order { get; set; }

        public int LineItem { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; } 

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
