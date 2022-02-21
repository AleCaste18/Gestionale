using Gestionale.Authorization;
using Gestionale.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gestionale.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@gestionale.com");
                await EnsureRole(serviceProvider, adminID, Constants.EmployeeAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@gestionale.com");
                await EnsureRole(serviceProvider, managerID, Constants.EmployeeManagersRole);

                var userID = await EnsureUser(serviceProvider, testUserPw, "user@gestionale.com");
                await EnsureRole(serviceProvider, userID, Constants.EmployeeUsersRole);

                SeedDB(context, testUserPw);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            context.Customers.AddRange(
                new Customer { CompanyName = "Azienda1", ContactName = "Cliente uno", Address = "Via della azienda 1" },
                new Customer { CompanyName = "Azienda2", ContactName = "Cliente due", Address = "Via della azienda 2" },
                new Customer { CompanyName = "Azienda3", ContactName = "Cliente tre", Address = "Via della azienda 3" },
                new Customer { CompanyName = "Azienda4", ContactName = "Cliente quattro", Address = "Via della azienda 4" },
                new Customer { CompanyName = "Azienda5", ContactName = "Cliente cinque", Address = "Via della azienda 5" }
                );
            context.SaveChanges();

            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            context.Employees.AddRange(
                new Employee { LastName = "CognomeDip uno", FirstName = "NomeDip uno", Address = "Via del dipendente 1", DOB = new DateTime(2022, 02, 15), OwnerID = adminID, Status = EmployeeStatus.Approved },
                new Employee { LastName = "CognomeDip due", FirstName = "NomeDip due", Address = "Via del dipendente 2", DOB = new DateTime(2022, 02, 15), OwnerID = adminID, Status = EmployeeStatus.Approved },
                new Employee { LastName = "CognomeDip tre", FirstName = "NomeDip tre", Address = "Via del dipendente 3", DOB = new DateTime(2022, 02, 15), OwnerID = adminID, Status = EmployeeStatus.Approved },
                new Employee { LastName = "CognomeDip quattro", FirstName = "NomeDip quattro", Address = "Via del dipendente 4", DOB = new DateTime(2022, 02, 15), OwnerID = adminID, Status = EmployeeStatus.Rejected },
                new Employee { LastName = "CognomeDip cinque", FirstName = "NomeDip cinque", Address = "Via del dipendente 5", DOB = new DateTime(2022, 02, 15), OwnerID = adminID, Status = EmployeeStatus.Rejected }
                );
            context.SaveChanges();


            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            context.Categories.AddRange(
                new Category { Name = "Prima Categoria" },
                new Category { Name = "Seconda Categoria" },
                new Category { Name = "Terza Categoria" },
                new Category { Name = "Quarta Categoria" },
                new Category { Name = "Quinta Categoria" }
                );
            context.SaveChanges();
            
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product { ProductName = "Prodotto uno", CategoryID = 3 },
                new Product { ProductName = "Prodotto due", CategoryID = 5 },
                new Product { ProductName = "Prodotto tre", CategoryID = 1 },
                new Product { ProductName = "Prodotto quattro", CategoryID = 2 },
                new Product { ProductName = "Prodotto cinque", CategoryID = 4 }
                );
            context.SaveChanges();

           

            if (context.Orders.Any())
            {
                return;   // DB has been seeded
            }

            context.Orders.AddRange(
                new Order { CustomerID = 4, EmployeeID = 5, OrderDate = new DateTime(2022, 02, 15), ShipAddress = "Via della spedizione 1" },
                new Order { CustomerID = 5, EmployeeID = 4, OrderDate = new DateTime(2022, 02, 15), ShipAddress = "Via della spedizione 2" },
                new Order { CustomerID = 2, EmployeeID = 3, OrderDate = new DateTime(2022, 02, 15), ShipAddress = "Via della spedizione 3" }
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


        }

    }
}
