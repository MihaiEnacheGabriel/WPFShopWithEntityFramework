using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPTema3.Migrations
{
    /// <inheritdoc />
    public partial class fourthtry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Categorie_CategorieID_categorie",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Producator_ProducatorID_producator",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusVandut_Produse_ProdusID_produs",
                table: "ProdusVandut");

            migrationBuilder.DropForeignKey(
                name: "FK_Stoc_Produse_ProdusID_produs",
                table: "Stoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produse",
                table: "Produse");

            migrationBuilder.RenameTable(
                name: "Produse",
                newName: "Produs");

            migrationBuilder.RenameColumn(
                name: "ID_bon",
                table: "ProdusVandut",
                newName: "ID_produsvandut");

            migrationBuilder.RenameIndex(
                name: "IX_Produse_ProducatorID_producator",
                table: "Produs",
                newName: "IX_Produs_ProducatorID_producator");

            migrationBuilder.RenameIndex(
                name: "IX_Produse_CategorieID_categorie",
                table: "Produs",
                newName: "IX_Produs_CategorieID_categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produs",
                table: "Produs",
                column: "ID_produs");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Categorie_CategorieID_categorie",
                table: "Produs",
                column: "CategorieID_categorie",
                principalTable: "Categorie",
                principalColumn: "ID_categorie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Producator_ProducatorID_producator",
                table: "Produs",
                column: "ProducatorID_producator",
                principalTable: "Producator",
                principalColumn: "ID_producator",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusVandut_Produs_ProdusID_produs",
                table: "ProdusVandut",
                column: "ProdusID_produs",
                principalTable: "Produs",
                principalColumn: "ID_produs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoc_Produs_ProdusID_produs",
                table: "Stoc",
                column: "ProdusID_produs",
                principalTable: "Produs",
                principalColumn: "ID_produs",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Categorie_CategorieID_categorie",
                table: "Produs");

            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Producator_ProducatorID_producator",
                table: "Produs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusVandut_Produs_ProdusID_produs",
                table: "ProdusVandut");

            migrationBuilder.DropForeignKey(
                name: "FK_Stoc_Produs_ProdusID_produs",
                table: "Stoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produs",
                table: "Produs");

            migrationBuilder.RenameTable(
                name: "Produs",
                newName: "Produse");

            migrationBuilder.RenameColumn(
                name: "ID_produsvandut",
                table: "ProdusVandut",
                newName: "ID_bon");

            migrationBuilder.RenameIndex(
                name: "IX_Produs_ProducatorID_producator",
                table: "Produse",
                newName: "IX_Produse_ProducatorID_producator");

            migrationBuilder.RenameIndex(
                name: "IX_Produs_CategorieID_categorie",
                table: "Produse",
                newName: "IX_Produse_CategorieID_categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produse",
                table: "Produse",
                column: "ID_produs");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Categorie_CategorieID_categorie",
                table: "Produse",
                column: "CategorieID_categorie",
                principalTable: "Categorie",
                principalColumn: "ID_categorie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Producator_ProducatorID_producator",
                table: "Produse",
                column: "ProducatorID_producator",
                principalTable: "Producator",
                principalColumn: "ID_producator",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusVandut_Produse_ProdusID_produs",
                table: "ProdusVandut",
                column: "ProdusID_produs",
                principalTable: "Produse",
                principalColumn: "ID_produs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoc_Produse_ProdusID_produs",
                table: "Stoc",
                column: "ProdusID_produs",
                principalTable: "Produse",
                principalColumn: "ID_produs",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
