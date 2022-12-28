using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Alura.Filmes.App.Migrations
{
    public partial class IndiceAtorUltimoNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "last_update",
                table: "language",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate");

            migrationBuilder.CreateIndex(
                name: "idx_actor_last_name",
                table: "actor",
                column: "last_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_actor_last_name",
                table: "actor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_update",
                table: "language",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");
        }
    }
}
