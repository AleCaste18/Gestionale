using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestionale.Data.Migrations
{
    public partial class addOwnerIDEmployeeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Prima Categoria" },
                    { 2, "Seconda Categoria" },
                    { 3, "Terza Categoria" },
                    { 4, "Quarta Categoria" },
                    { 5, "Quinta Categoria" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "CompanyName", "ContactName" },
                values: new object[,]
                {
                    { 1, "Via della azienda 1", "Azienda1", "Cliente uno" },
                    { 2, "Via della azienda 2", "Azienda2", "Cliente due" },
                    { 3, "Via della azienda 3", "Azienda3", "Cliente tre" },
                    { 4, "Via della azienda 4", "Azienda4", "Cliente quattro" },
                    { 5, "Via della azienda 5", "Azienda5", "Cliente cinque" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DOB", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Via del dipendente 1", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NomeDip uno", "CognomeDip uno" },
                    { 2, "Via del dipendente 2", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NomeDip due", "CognomeDip due" },
                    { 3, "Via del dipendente 3", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NomeDip tre", "CognomeDip tre" },
                    { 4, "Via del dipendente 4", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NomeDip quattro", "CognomeDip quattro" },
                    { 5, "Via del dipendente 5", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "NomeDip cinque", "CognomeDip cinque" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "EmployeeID", "OrderDate", "ShipAddress", "ShippedDate" },
                values: new object[,]
                {
                    { 1, 4, 5, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Via della spedizione 1", null },
                    { 2, 5, 4, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Via della spedizione 2", null },
                    { 3, 2, 3, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Via della spedizione 3", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Description", "ProductName" },
                values: new object[,]
                {
                    { 1, 3, null, "Prodotto uno" },
                    { 2, 5, null, "Prodotto due" },
                    { 3, 1, null, "Prodotto tre" },
                    { 4, 2, null, "Prodotto quattro" },
                    { 5, 4, null, "Prodotto cinque" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderID", "ProductID", "Discount", "Quantity", "UnitPrice" },
                values: new object[] { 1, 3, null, 5, 17.5m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderID", "ProductID", "Discount", "Quantity", "UnitPrice" },
                values: new object[] { 1, 5, null, 10, 30.0m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderID", "ProductID", "Discount", "Quantity", "UnitPrice" },
                values: new object[] { 2, 5, null, 15, 30.0m });
        }
    }
}
