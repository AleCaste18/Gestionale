using Gestionale.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestionale.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw = "")
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                SeedDB(context, testUserPw);
            }
        }

        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            context.Customers.AddRange(
                new Customer { CustomerID = 1, CompanyName = "Azienda1", ContactName = "Cliente uno", Address = "Via della azienda 1" },
                new Customer { CustomerID = 2, CompanyName = "Azienda2", ContactName = "Cliente due", Address = "Via della azienda 2" },
                new Customer { CustomerID = 3, CompanyName = "Azienda3", ContactName = "Cliente tre", Address = "Via della azienda 3" },
                new Customer { CustomerID = 4, CompanyName = "Azienda4", ContactName = "Cliente quattro", Address = "Via della azienda 4" },
                new Customer { CustomerID = 5, CompanyName = "Azienda5", ContactName = "Cliente cinque", Address = "Via della azienda 5" }
                );
            context.SaveChanges();

            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            context.Employees.AddRange(
                new Employee { EmployeeID = 1, LastName = "CognomeDip uno", FirstName = "NomeDip uno", Address = "Via del dipendente 1", DOB = new DateTime(2022, 02, 15) },
                new Employee { EmployeeID = 2, LastName = "CognomeDip due", FirstName = "NomeDip due", Address = "Via del dipendente 2", DOB = new DateTime(2022, 02, 15) },
                new Employee { EmployeeID = 3, LastName = "CognomeDip tre", FirstName = "NomeDip tre", Address = "Via del dipendente 3", DOB = new DateTime(2022, 02, 15) },
                new Employee { EmployeeID = 4, LastName = "CognomeDip quattro", FirstName = "NomeDip quattro", Address = "Via del dipendente 4", DOB = new DateTime(2022, 02, 15) },
                new Employee { EmployeeID = 5, LastName = "CognomeDip cinque", FirstName = "NomeDip cinque", Address = "Via del dipendente 5", DOB = new DateTime(2022, 02, 15) }
                );
            context.SaveChanges();


            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            context.Categories.AddRange(
                new Category { CategoryID = 1, Name = "Prima Categoria" },
                new Category { CategoryID = 2, Name = "Seconda Categoria" },
                new Category { CategoryID = 3, Name = "Terza Categoria" },
                new Category { CategoryID = 4, Name = "Quarta Categoria" },
                new Category { CategoryID = 5, Name = "Quinta Categoria" }
                );
            context.SaveChanges();
            
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product { ProductID = 1, ProductName = "Prodotto uno", CategoryID = 3 },
                new Product { ProductID = 2, ProductName = "Prodotto due", CategoryID = 5 },
                new Product { ProductID = 3, ProductName = "Prodotto tre", CategoryID = 1 },
                new Product { ProductID = 4, ProductName = "Prodotto quattro", CategoryID = 2 },
                new Product { ProductID = 5, ProductName = "Prodotto cinque", CategoryID = 4 }
                );
            context.SaveChanges();

            if (context.OrderDetails.Any())
            {
                return;   // DB has been seeded
            }

            context.OrderDetails.AddRange(
                new OrderDetail { OrderID = 1, ProductID = 3, Quantity = 5, UnitPrice = 17.5m },
                new OrderDetail { OrderID = 1, ProductID = 5, Quantity = 10, UnitPrice = 30.0m },
                new OrderDetail { OrderID = 2, ProductID = 5, Quantity = 15, UnitPrice = 30.0m }
                );
            context.SaveChanges();

            if (context.Orders.Any())
            {
                return;   // DB has been seeded
            }

            context.Orders.AddRange(
                new Order { OrderID = 1, CustomerID = 4, EmployeeID = 5, OrderDate = new DateTime(2022, 02, 15), ShipAddress = "Via della spedizione 1" },
                new Order { OrderID = 2, CustomerID = 5, EmployeeID = 4, OrderDate = new DateTime(2022, 02, 15), ShipAddress = "Via della spedizione 2" },
                new Order { OrderID = 3, CustomerID = 2, EmployeeID = 3, OrderDate = new DateTime(2022, 02, 15), ShipAddress = "Via della spedizione 3" }
                );
            context.SaveChanges();

        }

    }
}
