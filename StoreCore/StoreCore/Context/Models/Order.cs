namespace StoreCore.Context.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public OrderDetails OrderDetails { get; set; }
    }
}
