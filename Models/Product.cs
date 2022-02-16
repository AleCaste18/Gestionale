namespace Gestionale.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string? Description { get; set; }

        public Category Category { get; set; }
        public int CategoryID { get; set; }

        public ICollection<OrderDetail> orderDetails { get; set; }

    }
}
