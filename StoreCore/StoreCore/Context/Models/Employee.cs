namespace StoreCore.Context.Models
{
    public class Employee: APerson
    {
        public int Id { get; set; }

        public int Salary { get; set; }
        public int PriorSalary { get; set; }

        public DateTime HireDate { get; set; }
        public DateTime TerminationDate { get; set; }

        // ? what is it ?
        public int ManagerEmpId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
