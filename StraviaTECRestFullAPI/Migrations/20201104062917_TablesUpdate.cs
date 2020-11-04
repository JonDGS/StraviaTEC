using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StraviaTECRestFullAPI.Migrations
{
    public partial class TablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_athletes",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "address",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "email",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "athletes");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "athletes",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "athletes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "athletes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname_1",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname_2",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nationality",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "passwordHash",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "athletes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_athletes",
                table: "athletes",
                columns: new[] { "id", "username" });

            migrationBuilder.CreateTable(
                name: "organizers",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    id = table.Column<string>(nullable: false),
                    passwordHash = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    lastname_1 = table.Column<string>(nullable: true),
                    lastname_2 = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizers", x => new { x.id, x.username });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_athletes",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "username",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "city",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "country",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "lastname_1",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "lastname_2",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "nationality",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "passwordHash",
                table: "athletes");

            migrationBuilder.DropColumn(
                name: "state",
                table: "athletes");

            migrationBuilder.AlterColumn<float>(
                name: "age",
                table: "athletes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "athletes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "athletes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "athletes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "athletes",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_athletes",
                table: "athletes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    age = table.Column<float>(type: "real", nullable: false),
                    city = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });
        }
    }
}
