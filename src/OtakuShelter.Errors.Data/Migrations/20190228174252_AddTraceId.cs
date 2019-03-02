using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Errors.Migrations
{
    public partial class AddTraceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "trace_id",
                table: "errors",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "UI_trace_id",
                table: "errors",
                column: "trace_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UI_trace_id",
                table: "errors");

            migrationBuilder.DropColumn(
                name: "trace_id",
                table: "errors");
        }
    }
}
