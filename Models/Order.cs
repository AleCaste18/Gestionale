namespace Gestionale.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipAddress { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Customer Customer { get; set; }
        public int CustomerID { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}
