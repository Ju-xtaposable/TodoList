using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    public partial class updateeventpourcalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "Event",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "DateFin",
                table: "Event",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "DateDebut",
                table: "Event",
                newName: "End");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Event",
                newName: "Titre");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Event",
                newName: "DateFin");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Event",
                newName: "DateDebut");
        }
    }
}
