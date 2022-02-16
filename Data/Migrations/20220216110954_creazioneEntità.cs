using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestionale.Data.Migrations
{
    public partial class creazioneEntità : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
