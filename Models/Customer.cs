namespace Gestionale.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
