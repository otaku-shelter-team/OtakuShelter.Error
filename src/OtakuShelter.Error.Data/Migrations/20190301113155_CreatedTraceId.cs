using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Error.Migrations
{
    public partial class CreatedTraceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated",
                table: "errors");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "trace_ids",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created",
                table: "trace_ids");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated",
                table: "errors",
                nullable: true);
        }
    }
}
