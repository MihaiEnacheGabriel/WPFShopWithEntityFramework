using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPTema3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID_categorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_categorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID_categorie);
                });

            migrationBuilder.CreateTable(
                name: "Producators",
                columns: table => new
                {
                    ID_producator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_producator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tara_origine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producators", x => x.ID_producator);
                });

            migrationBuilder.CreateTable(
                name: "Utilizators",
                columns: table => new
                {
                    ID_utilizator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_utilizator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizators", x => x.ID_utilizator);
                });

            migrationBuilder.CreateTable(
                name: "Produses",
                columns: table => new
                {
                    ID_produs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_produs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_bare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_categorie = table.Column<int>(type: "int", nullable: false),
                    ID_producator = table.Column<int>(type: "int", nullable: false),
                    In_stock = table.Column<bool>(type: "bit", nullable: false),
                    CategorieID_categorie = table.Column<int>(type: "int", nullable: false),
                    ProducatorID_producator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produses", x => x.ID_produs);
                    table.ForeignKey(
                        name: "FK_Produses_Categories_CategorieID_categorie",
                        column: x => x.CategorieID_categorie,
                        principalTable: "Categories",
                        principalColumn: "ID_categorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produses_Producators_ProducatorID_producator",
                        column: x => x.ProducatorID_producator,
                        principalTable: "Producators",
                        principalColumn: "ID_producator",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bons",
                columns: table => new
                {
                    ID_bon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_eliberare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_casier = table.Column<int>(type: "int", nullable: false),
                    Suma_incasata = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CasierID_utilizator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bons", x => x.ID_bon);
                    table.ForeignKey(
                        name: "FK_Bons_Utilizators_CasierID_utilizator",
                        column: x => x.CasierID_utilizator,
                        principalTable: "Utilizators",
                        principalColumn: "ID_utilizator",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocs",
                columns: table => new
                {
                    ID_stoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_produs = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    Unitate_masura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_aprovizionare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_expirare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pret_achizitie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pret_vanzare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProdusID_produs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocs", x => x.ID_stoc);
                    table.ForeignKey(
                        name: "FK_Stocs_Produses_ProdusID_produs",
                        column: x => x.ProdusID_produs,
                        principalTable: "Produses",
                        principalColumn: "ID_produs",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdusVanduts",
                columns: table => new
                {
                    ID_bon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_produs = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonID_bon = table.Column<int>(type: "int", nullable: false),
                    ProdusID_produs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdusVanduts", x => x.ID_bon);
                    table.ForeignKey(
                        name: "FK_ProdusVanduts_Bons_BonID_bon",
                        column: x => x.BonID_bon,
                        principalTable: "Bons",
                        principalColumn: "ID_bon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdusVanduts_Produses_ProdusID_produs",
                        column: x => x.ProdusID_produs,
                        principalTable: "Produses",
                        principalColumn: "ID_produs",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bons_CasierID_utilizator",
                table: "Bons",
                column: "CasierID_utilizator");

            migrationBuilder.CreateIndex(
                name: "IX_Produses_CategorieID_categorie",
                table: "Produses",
                column: "CategorieID_categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Produses_ProducatorID_producator",
                table: "Produses",
                column: "ProducatorID_producator");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusVanduts_BonID_bon",
                table: "ProdusVanduts",
                column: "BonID_bon");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusVanduts_ProdusID_produs",
                table: "ProdusVanduts",
                column: "ProdusID_produs");

            migrationBuilder.CreateIndex(
                name: "IX_Stocs_ProdusID_produs",
                table: "Stocs",
                column: "ProdusID_produs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdusVanduts");

            migrationBuilder.DropTable(
                name: "Stocs");

            migrationBuilder.DropTable(
                name: "Bons");

            migrationBuilder.DropTable(
                name: "Produses");

            migrationBuilder.DropTable(
                name: "Utilizators");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Producators");
        }
    }
}
