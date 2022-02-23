using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tache_Categorie_CategorisId",
                table: "Tache");

            migrationBuilder.RenameColumn(
                name: "CategorisId",
                table: "Tache",
                newName: "CategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Tache_CategorisId",
                table: "Tache",
                newName: "IX_Tache_CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tache_Categorie_CategorieId",
                table: "Tache",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tache_Categorie_CategorieId",
                table: "Tache");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Tache",
                newName: "CategorisId");

            migrationBuilder.RenameIndex(
                name: "IX_Tache_CategorieId",
                table: "Tache",
                newName: "IX_Tache_CategorisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tache_Categorie_CategorisId",
                table: "Tache",
                column: "CategorisId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
