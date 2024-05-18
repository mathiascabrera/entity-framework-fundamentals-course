using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace project_EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Description", "EffortLevel", "Name" },
                values: new object[,]
                {
                    { new Guid("a803e17f-b1e9-4e69-a426-0ae1a5ba0dc3"), null, 50, "Personal activities" },
                    { new Guid("d8d1e903-0c79-4e92-9fc1-df471bd2882d"), null, 20, "Pending activities" }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "TimeLimit", "Title" },
                values: new object[,]
                {
                    { new Guid("04799f58-7631-4371-aa78-41f7e06f758f"), new Guid("d8d1e903-0c79-4e92-9fc1-df471bd2882d"), new DateTime(2024, 5, 18, 11, 21, 24, 421, DateTimeKind.Local).AddTicks(6795), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payment of public services" },
                    { new Guid("986cf55a-4c1d-477f-8719-3acf5695f8ce"), new Guid("a803e17f-b1e9-4e69-a426-0ae1a5ba0dc3"), new DateTime(2024, 5, 18, 11, 21, 24, 421, DateTimeKind.Local).AddTicks(6812), null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish watching the movie on netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskId",
                keyValue: new Guid("04799f58-7631-4371-aa78-41f7e06f758f"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskId",
                keyValue: new Guid("986cf55a-4c1d-477f-8719-3acf5695f8ce"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("a803e17f-b1e9-4e69-a426-0ae1a5ba0dc3"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("d8d1e903-0c79-4e92-9fc1-df471bd2882d"));
        }
    }
}
