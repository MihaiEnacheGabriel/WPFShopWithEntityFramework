using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPTema3.Migrations
{
    /// <inheritdoc />
    public partial class fifthtry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_produs",
                table: "ProdusVandut");

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "Bon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "Bon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "Bon");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "Bon");

            migrationBuilder.AddColumn<int>(
                name: "ID_produs",
                table: "ProdusVandut",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
