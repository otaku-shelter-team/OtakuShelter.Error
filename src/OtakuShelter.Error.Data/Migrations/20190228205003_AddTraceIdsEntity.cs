using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Error.Migrations
{
    public partial class AddTraceIdsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UI_trace_id",
                table: "errors");

            migrationBuilder.DropColumn(
                name: "trace_id",
                table: "errors");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated",
                table: "errors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "trace_ids",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    error_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trace_ids", x => x.id);
                    table.ForeignKey(
                        name: "FK_error_trace_ids",
                        column: x => x.error_id,
                        principalTable: "errors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trace_ids_error_id",
                table: "trace_ids",
                column: "error_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trace_ids");

            migrationBuilder.DropColumn(
                name: "updated",
                table: "errors");

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
    }
}
