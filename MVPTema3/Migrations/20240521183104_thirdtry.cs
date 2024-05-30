using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPTema3.Migrations
{
    /// <inheritdoc />
    public partial class thirdtry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bons_Utilizators_CasierID_utilizator",
                table: "Bons");

            migrationBuilder.DropForeignKey(
                name: "FK_Produses_Categories_CategorieID_categorie",
                table: "Produses");

            migrationBuilder.DropForeignKey(
                name: "FK_Produses_Producators_ProducatorID_producator",
                table: "Produses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusVanduts_Bons_BonID_bon",
                table: "ProdusVanduts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusVanduts_Produses_ProdusID_produs",
                table: "ProdusVanduts");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocs_Produses_ProdusID_produs",
                table: "Stocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizators",
                table: "Utilizators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocs",
                table: "Stocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdusVanduts",
                table: "ProdusVanduts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produses",
                table: "Produses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producators",
                table: "Producators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bons",
                table: "Bons");

            migrationBuilder.DropColumn(
                name: "ID_produs",
                table: "Stocs");

            migrationBuilder.DropColumn(
                name: "ID_categorie",
                table: "Produses");

            migrationBuilder.DropColumn(
                name: "ID_producator",
                table: "Produses");

            migrationBuilder.DropColumn(
                name: "ID_casier",
                table: "Bons");

            migrationBuilder.RenameTable(
                name: "Utilizators",
                newName: "Utilizator");

            migrationBuilder.RenameTable(
                name: "Stocs",
                newName: "Stoc");

            migrationBuilder.RenameTable(
                name: "ProdusVanduts",
                newName: "ProdusVandut");

            migrationBuilder.RenameTable(
                name: "Produses",
                newName: "Produse");

            migrationBuilder.RenameTable(
                name: "Producators",
                newName: "Producator");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorie");

            migrationBuilder.RenameTable(
                name: "Bons",
                newName: "Bon");

            migrationBuilder.RenameIndex(
                name: "IX_Stocs_ProdusID_produs",
                table: "Stoc",
                newName: "IX_Stoc_ProdusID_produs");

            migrationBuilder.RenameIndex(
                name: "IX_ProdusVanduts_ProdusID_produs",
                table: "ProdusVandut",
                newName: "IX_ProdusVandut_ProdusID_produs");

            migrationBuilder.RenameIndex(
                name: "IX_ProdusVanduts_BonID_bon",
                table: "ProdusVandut",
                newName: "IX_ProdusVandut_BonID_bon");

            migrationBuilder.RenameIndex(
                name: "IX_Produses_ProducatorID_producator",
                table: "Produse",
                newName: "IX_Produse_ProducatorID_producator");

            migrationBuilder.RenameIndex(
                name: "IX_Produses_CategorieID_categorie",
                table: "Produse",
                newName: "IX_Produse_CategorieID_categorie");

            migrationBuilder.RenameIndex(
                name: "IX_Bons_CasierID_utilizator",
                table: "Bon",
                newName: "IX_Bon_CasierID_utilizator");

            migrationBuilder.AddColumn<bool>(
                name: "Is_Active",
                table: "Utilizator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Active",
                table: "Stoc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Active",
                table: "Produse",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Active",
                table: "Producator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Active",
                table: "Categorie",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Active",
                table: "Bon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizator",
                table: "Utilizator",
                column: "ID_utilizator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stoc",
                table: "Stoc",
                column: "ID_stoc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdusVandut",
                table: "ProdusVandut",
                column: "ID_bon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produse",
                table: "Produse",
                column: "ID_produs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producator",
                table: "Producator",
                column: "ID_producator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "ID_categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bon",
                table: "Bon",
                column: "ID_bon");

            migrationBuilder.AddForeignKey(
                name: "FK_Bon_Utilizator_CasierID_utilizator",
                table: "Bon",
                column: "CasierID_utilizator",
                principalTable: "Utilizator",
                principalColumn: "ID_utilizator",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ProdusVandut_Bon_BonID_bon",
                table: "ProdusVandut",
                column: "BonID_bon",
                principalTable: "Bon",
                principalColumn: "ID_bon",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bon_Utilizator_CasierID_utilizator",
                table: "Bon");

            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Categorie_CategorieID_categorie",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Producator_ProducatorID_producator",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusVandut_Bon_BonID_bon",
                table: "ProdusVandut");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusVandut_Produse_ProdusID_produs",
                table: "ProdusVandut");

            migrationBuilder.DropForeignKey(
                name: "FK_Stoc_Produse_ProdusID_produs",
                table: "Stoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizator",
                table: "Utilizator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stoc",
                table: "Stoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdusVandut",
                table: "ProdusVandut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produse",
                table: "Produse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producator",
                table: "Producator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bon",
                table: "Bon");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Utilizator");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Stoc");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Producator");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Bon");

            migrationBuilder.RenameTable(
                name: "Utilizator",
                newName: "Utilizators");

            migrationBuilder.RenameTable(
                name: "Stoc",
                newName: "Stocs");

            migrationBuilder.RenameTable(
                name: "ProdusVandut",
                newName: "ProdusVanduts");

            migrationBuilder.RenameTable(
                name: "Produse",
                newName: "Produses");

            migrationBuilder.RenameTable(
                name: "Producator",
                newName: "Producators");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Bon",
                newName: "Bons");

            migrationBuilder.RenameIndex(
                name: "IX_Stoc_ProdusID_produs",
                table: "Stocs",
                newName: "IX_Stocs_ProdusID_produs");

            migrationBuilder.RenameIndex(
                name: "IX_ProdusVandut_ProdusID_produs",
                table: "ProdusVanduts",
                newName: "IX_ProdusVanduts_ProdusID_produs");

            migrationBuilder.RenameIndex(
                name: "IX_ProdusVandut_BonID_bon",
                table: "ProdusVanduts",
                newName: "IX_ProdusVanduts_BonID_bon");

            migrationBuilder.RenameIndex(
                name: "IX_Produse_ProducatorID_producator",
                table: "Produses",
                newName: "IX_Produses_ProducatorID_producator");

            migrationBuilder.RenameIndex(
                name: "IX_Produse_CategorieID_categorie",
                table: "Produses",
                newName: "IX_Produses_CategorieID_categorie");

            migrationBuilder.RenameIndex(
                name: "IX_Bon_CasierID_utilizator",
                table: "Bons",
                newName: "IX_Bons_CasierID_utilizator");

            migrationBuilder.AddColumn<int>(
                name: "ID_produs",
                table: "Stocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_categorie",
                table: "Produses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_producator",
                table: "Produses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_casier",
                table: "Bons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizators",
                table: "Utilizators",
                column: "ID_utilizator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocs",
                table: "Stocs",
                column: "ID_stoc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdusVanduts",
                table: "ProdusVanduts",
                column: "ID_bon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produses",
                table: "Produses",
                column: "ID_produs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producators",
                table: "Producators",
                column: "ID_producator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID_categorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bons",
                table: "Bons",
                column: "ID_bon");

            migrationBuilder.AddForeignKey(
                name: "FK_Bons_Utilizators_CasierID_utilizator",
                table: "Bons",
                column: "CasierID_utilizator",
                principalTable: "Utilizators",
                principalColumn: "ID_utilizator",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produses_Categories_CategorieID_categorie",
                table: "Produses",
                column: "CategorieID_categorie",
                principalTable: "Categories",
                principalColumn: "ID_categorie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produses_Producators_ProducatorID_producator",
                table: "Produses",
                column: "ProducatorID_producator",
                principalTable: "Producators",
                principalColumn: "ID_producator",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusVanduts_Bons_BonID_bon",
                table: "ProdusVanduts",
                column: "BonID_bon",
                principalTable: "Bons",
                principalColumn: "ID_bon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusVanduts_Produses_ProdusID_produs",
                table: "ProdusVanduts",
                column: "ProdusID_produs",
                principalTable: "Produses",
                principalColumn: "ID_produs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocs_Produses_ProdusID_produs",
                table: "Stocs",
                column: "ProdusID_produs",
                principalTable: "Produses",
                principalColumn: "ID_produs",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
