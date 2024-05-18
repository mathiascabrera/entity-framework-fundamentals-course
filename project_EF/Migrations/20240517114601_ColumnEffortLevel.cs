using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_EF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEffortLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EffortLevel",
                table: "Categoria",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffortLevel",
                table: "Categoria");
        }
    }
}
