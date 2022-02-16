namespace Gestionale.Models
{
    public class OrderDetail
    {
        public Order Order { get; set; }
        public int OrderID { get; set; }

        public Product Product { get; set; }
        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }



    }
}
