namespace Gestionale.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }


        public string? OwnerID { get; set; }
        public EmployeeStatus Status { get; set; }
    }

    public enum EmployeeStatus 
    {
        Submitted,
        Approved,
        Rejected
    }

}
