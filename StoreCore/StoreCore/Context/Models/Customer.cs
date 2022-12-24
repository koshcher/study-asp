namespace StoreCore.Context.Models
{
    public class Customer: APerson
    {
        public int Id { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public DateTime DateInSystem { get; set; }

        public List<Order> Orders { get; set; }
    }
}
