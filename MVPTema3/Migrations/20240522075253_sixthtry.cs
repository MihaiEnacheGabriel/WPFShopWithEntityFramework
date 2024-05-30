using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPTema3.Migrations
{
    /// <inheritdoc />
    public partial class sixthtry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdaosComercial",
                table: "Stoc",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdaosComercial",
                table: "Stoc");
        }
    }
}
