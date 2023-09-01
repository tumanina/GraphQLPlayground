using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQLPlayground.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreaatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "Notes" },
                values: new object[,]
                {
                    { new Guid("9c0373db-994e-44b5-9ed0-d18936ecfe19"), "John", "Doe", "Customer John Doe" },
                    { new Guid("aeab639a-efd1-4bf2-81d8-0c068f7cc692"), "James", "Smith", "Customer James Smith" },
                    { new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"), "Jane", "Doe", "Customer Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreaatedAt", "CustomerId", "Status" },
                values: new object[,]
                {
                    { new Guid("026f0bd5-dfe6-4b77-942c-9ab5aabbd4f6"), new DateTime(2023, 8, 28, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6268), new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"), "Delivered" },
                    { new Guid("3a23cb7b-9385-48e6-b9cf-c80ec74a831a"), new DateTime(2023, 8, 30, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6270), new Guid("9c0373db-994e-44b5-9ed0-d18936ecfe19"), "Placed." },
                    { new Guid("48953dff-8b4f-4164-8a05-ff54412d4fda"), new DateTime(2023, 8, 30, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6271), new Guid("aeab639a-efd1-4bf2-81d8-0c068f7cc692"), "Delivered" },
                    { new Guid("8a9be312-c805-49bb-b65e-96e5bc561768"), new DateTime(2023, 8, 29, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6267), new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"), "Shipped" },
                    { new Guid("a313c969-3fe7-41e9-8563-9e660d5038e8"), new DateTime(2023, 8, 30, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6245), new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"), "Placed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
