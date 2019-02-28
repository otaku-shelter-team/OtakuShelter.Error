using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Error.Migrations
{
    public partial class AddUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UI_project_type_message",
                table: "errors",
                columns: new[] { "project", "type", "message" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UI_project_type_message",
                table: "errors");
        }
    }
}
